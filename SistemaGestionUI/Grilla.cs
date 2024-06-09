using SistemaGestionBussiness;
using SistemaGestionEntities;
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
    public partial class Grilla : Form
    {
        public Grilla()
        {
            InitializeComponent();
            string labelText = "Grilla " + Program.instancia;
            this.label1.Text = labelText;
            cargarTabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.inicio.Show();
        }
        public void cargarUsuarios()
        {
            List<Usuario> usuarios = UsuarioNegocio.GetUsuarios();
            dgvGrilla.AutoGenerateColumns = true;
            dgvGrilla.DataSource = usuarios;
        }
        public void cargarProductos()
        {
            List<Producto> productos = ProductoNegocio.GetProductos();
            dgvGrilla.AutoGenerateColumns = true;
            dgvGrilla.DataSource = productos;
        }
        public void cargarVentas()
        {
            List<Venta> ventas = VentaNegocio.GetVentas();
            dgvGrilla.AutoGenerateColumns = true;
            dgvGrilla.DataSource = ventas;
        }
        public void cargarProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = ProductoVendidoNegocio.GetProductosVendidos();
            dgvGrilla.AutoGenerateColumns = true;
            dgvGrilla.DataSource = productosVendidos;
        }

        public void cargarTabla()
        {
            switch (Program.instancia)
            {
                case "Usuario":
                    cargarUsuarios();
                    break;
                case "Producto":
                    cargarProductos();
                    break;
                case "Venta":
                    cargarVentas();
                    break;
                case "ProductoVendido":
                    cargarProductosVendidos();
                    break;
            }
        }
        private void dgvGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowSeleccionada = (int)e.RowIndex;
                Program.idSelected = int.Parse(dgvGrilla[0, rowSeleccionada].Value.ToString());

                Formulario formulario = new Formulario();
                Inicio.grilla.Hide();
                formulario.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.idSelected = 0;

            Formulario formulario = new Formulario();
            Inicio.grilla.Hide();
            formulario.Show();
        }
    }
}
