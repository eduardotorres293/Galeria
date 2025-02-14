using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica2
{
    public partial class Form1 : Form
    {
        private string[] imagenes;

        public Form1()
        {
            InitializeComponent();
            CargarImagenes();
            MostrarImagen();
        }

        private void CargarImagenes()
        {
            string carpeta = Path.Combine(Application.StartupPath, @"..\..\Imagenes");
            if (Directory.Exists(carpeta))
            {
                imagenes = Directory.GetFiles(carpeta, "*.jpg").Concat(Directory.GetFiles(carpeta, "*.png")).ToArray();
            }
            else
            {
                MessageBox.Show("La carpeta no existe o no está asignada");
                imagenes = new string[0];
            }
        }

        private void MostrarImagen()
        {
            flowLayoutPanel2.Controls.Clear();

            if (imagenes.Length > 0)
            {
                foreach (var imagen in imagenes)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        ImageLocation = imagen,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 200,
                        Height = 200,
                        Margin = new Padding(10)
                    };
                    pictureBox.Click += (sender, e) => abrirForm(imagen);
                    flowLayoutPanel2.Controls.Add(pictureBox);
                }
            }
        }
        private void abrirForm(string imagen)
        {
            string nombreImagen = Path.GetFileNameWithoutExtension(imagen);
            imagenGrande imagenFormulario = new imagenGrande(imagen, nombreImagen);
            imagenFormulario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string openFolder = Path.Combine(Application.StartupPath, @"..\..\Imagenes");
            System.Diagnostics.Process.Start(openFolder);
        }
    }
}
