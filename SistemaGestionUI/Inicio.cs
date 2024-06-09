using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionUI
{
    public partial class Inicio : Form
    {
        public static Grilla grilla;
        public Inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.instancia = "Usuario";
            grilla = new Grilla();
            Program.inicio.Hide();
            grilla.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.instancia = "Producto";
            grilla = new Grilla();
            Program.inicio.Hide();
            grilla.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.instancia = "Venta";
            grilla = new Grilla();
            Program.inicio.Hide();
            grilla.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.instancia = "ProductoVendido";
            grilla = new Grilla();
            Program.inicio.Hide();
            grilla.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
