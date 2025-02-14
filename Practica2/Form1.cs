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
            this.Resize += Form1_Resize;
        }
        // Función que permite cargar las imagenes desde una carpeta asignada, para despues mostrarlas mediante otra función
        private void CargarImagenes()
        {
            string carpeta = Path.Combine(Application.StartupPath, @"..\..\Imagenes"); // Mediante un Path se crea la ruta a la carpeta de imagenes que est+a junto a la solución
            // Primero verifica si dicha carpeta existe mediante el uso del directorio
            if (Directory.Exists(carpeta))
            {
                // Se usa la variable imagenes, y se le asigna en base a la imagen que haya conseguido en la carpeta
                imagenes = Directory.GetFiles(carpeta, "*.jpg") // Para archivos jpg
                    .Concat(Directory.GetFiles(carpeta, "*.png")) // Para archivos png
                    .Concat(Directory.GetFiles(carpeta, "*.jpeg")) // Para archivos jpeg
                    .Concat(Directory.GetFiles(carpeta, "*.jfif")) // Para archivos jfif (archivos raros de ver, pero pueden llegar a ser utilizados)
                    .Concat(Directory.GetFiles(carpeta, "*.gif")) // Para archivos gif, que requieran movimiento
                    .ToArray();
                // Este es una forma de verificar si no hay archivos en el programa
                if (imagenes.Length == 0) // Si el tamaño de las imagenes es igual a 0, entonces se muestra el label cuyo texto es "No hay imagenes para mostrar"
                {
                    label1.Visible = true; // Se hace true
                }
                else
                {
                    label1.Visible = false; // Si no es el caso, entonces no se muestra dicho label
                }
            }
            // Si dicha carpeta no existe, entonces se hace un mensaje de error donde menciona que no hay una carpeta asignada o no existe
            else
            {
                MessageBox.Show("La carpeta no existe o no está asignada");
                imagenes = new string[0];
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            int anchoPanel = flowLayoutPanel2.Width;
            int numeroDeImagenesPorFila = anchoPanel / 220;
            if (numeroDeImagenesPorFila == 0)
            {
                numeroDeImagenesPorFila = 1; 
            }
            int nuevoAncho = (anchoPanel / numeroDeImagenesPorFila) - 10;

            foreach (PictureBox pictureBox in flowLayoutPanel2.Controls)
            {
                pictureBox.Width = nuevoAncho;
                pictureBox.Height = nuevoAncho;
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

        private void button1_Click(object sender, EventArgs e)
        {
            CargarImagenes();
            MostrarImagen();
        }
    }
}
