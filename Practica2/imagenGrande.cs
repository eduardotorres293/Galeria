using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica2
{
    public partial class imagenGrande : Form
    {
        public imagenGrande(string imagenPath, string nombreImagen)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = imagenPath;
            this.Text = nombreImagen;
        }
    }
}
