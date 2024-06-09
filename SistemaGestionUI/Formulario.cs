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
    public partial class Formulario : Form
    {
        public Formulario()
        {
            InitializeComponent();
            if(Program.idSelected > 0)
            {
                this.button2.Text = "Eliminar";
                this.button3.Text = "Modificar";
            }
            else
            {
                this.button2.Text = "Crear";
                this.button3.Hide();
            }
            switch (Program.instancia)
            {
                case "Usuario":
                    FormUsuario();
                    break;
                case "Producto":
                    FormProducto();
                    break;
                case "Venta":
                    FormVenta();
                    break;
                case "ProductoVendido":
                    FormProductoVendido();
                    break;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.modificar = false;
            this.Close();
            Inicio.grilla.Show();
        }
        private void FormUsuario()
        {
            this.label1.Text = "ID";
            this.label2.Text = "Nombre";
            this.label3.Text = "Apellido";
            this.label4.Text = "Usuario";
            this.label5.Text = "Contraseña";
            this.label6.Text = "Email";
            this.textBox1.ReadOnly = true;

            if (Program.idSelected > 0)
            {
                Usuario usuario = UsuarioNegocio.GetUsuario(Program.idSelected);

                this.textBox2.ReadOnly = true;
                this.textBox3.ReadOnly = true;
                this.textBox4.ReadOnly = true;
                this.textBox5.ReadOnly = true;
                this.textBox6.ReadOnly = true;
                this.textBox1.Text = usuario.Id.ToString();
                this.textBox2.Text = usuario.Nombre;
                this.textBox3.Text = usuario.Apellido;
                this.textBox4.Text = usuario.NombreUsuario;
                this.textBox5.Text = usuario.Password;
                this.textBox6.Text = usuario.Email;
            }
            else
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
            }
        }
        private void FormProducto()
        {
            this.label1.Text = "ID";
            this.label2.Text = "Descripción";
            this.label3.Text = "Costo";
            this.label4.Text = "Precio venta";
            this.label5.Text = "Stock";
            this.label6.Text = "ID Usuario";
            this.textBox1.ReadOnly = true;

            if (Program.idSelected > 0)
            {
                Producto producto = ProductoNegocio.GetProducto(Program.idSelected);

                this.textBox2.ReadOnly = true;
                this.textBox3.ReadOnly = true;
                this.textBox4.ReadOnly = true;
                this.textBox5.ReadOnly = true;
                this.textBox6.ReadOnly = true;
                this.textBox1.Text = producto.Id.ToString();
                this.textBox2.Text = producto.Descripcion;
                this.textBox3.Text = producto.Costo.ToString();
                this.textBox4.Text = producto.PrecioVenta.ToString();
                this.textBox5.Text = producto.Stock.ToString();
                this.textBox6.Text = producto.IdUsuario.ToString();
            }
            else
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
            }
        }
        private void FormVenta()
        {
            this.label1.Text = "";
            this.label2.Text = "ID";
            this.label3.Text = "Comentarios";
            this.label4.Text = "ID Usuario";
            this.label5.Text = "";
            this.label6.Text = "";
            this.textBox1.Hide();
            this.textBox2.ReadOnly = true;
            this.textBox5.Hide();
            this.textBox6.Hide();

            if (Program.idSelected > 0)
            {
                Venta venta = VentaNegocio.GetVenta(Program.idSelected);

                this.textBox3.ReadOnly = true;
                this.textBox4.ReadOnly = true;
                this.textBox2.Text = venta.Id.ToString();
                this.textBox3.Text = venta.Comentarios;
                this.textBox4.Text = venta.IdUsuario.ToString();
            }
            else
            {
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
            }
        }
        private void FormProductoVendido()
        {
            this.label1.Text = "";
            this.label2.Text = "ID";
            this.label3.Text = "Stock";
            this.label4.Text = "ID Producto";
            this.label5.Text = "ID Venta";
            this.label6.Text = "";
            this.textBox1.Hide();
            this.textBox2.ReadOnly = true;
            this.textBox6.Hide();

            if (Program.idSelected > 0)
            {
                ProductoVendido productoVendido = ProductoVendidoNegocio.GetProductoVendido(Program.idSelected);

                this.textBox3.ReadOnly = true;
                this.textBox4.ReadOnly = true;
                this.textBox5.ReadOnly = true;
                this.textBox2.Text = productoVendido.Id.ToString();
                this.textBox3.Text = productoVendido.IdProducto.ToString();
                this.textBox4.Text = productoVendido.Stock.ToString();
                this.textBox5.Text = productoVendido.IdVenta.ToString();
            }
            else
            {
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
            }
        }

        private void ModificarUsuario()
        {
            int id = Program.idSelected;
            string nombre = this.textBox2.Text;
            string apellido = this.textBox3.Text;
            string nombreUsuario = this.textBox4.Text;
            string password = this.textBox5.Text;
            string email = this.textBox6.Text;

            UsuarioNegocio.UpdateUsuario(id, nombre, apellido, nombreUsuario, password, email);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }
        private void ModificarProducto()
        {
            int id = Program.idSelected;
            string descripcion = this.textBox2.Text;
            int costo = int.Parse(this.textBox3.Text);
            int precioVenta = int.Parse(this.textBox4.Text);
            int stock = int.Parse(this.textBox5.Text);
            int idUsuario = int.Parse(this.textBox6.Text);

            ProductoNegocio.UpdateProducto(id, descripcion, costo, precioVenta, stock, idUsuario);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }
        private void ModificarVenta()
        {
            int id = Program.idSelected;
            string comentarios = this.textBox3.Text;
            int idUsuario = int.Parse(this.textBox4.Text);

            VentaNegocio.UpdateVenta(id, comentarios, idUsuario);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }
        private void ModificarProductoVendido()
        {
            int id = Program.idSelected;
            int stock = int.Parse(this.textBox3.Text);
            int idProducto = int.Parse(this.textBox4.Text);
            int idVenta = int.Parse(this.textBox5.Text);

            ProductoVendidoNegocio.UpdateProductoVendido(id, stock, idProducto, idVenta);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }

        private void EliminarUsuario()
        {
            UsuarioNegocio.DeleteUsuario(Program.idSelected);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }
        private void EliminarProducto()
        {
            ProductoNegocio.DeleteProducto(Program.idSelected);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }
        private void EliminarVenta()
        {
            VentaNegocio.DeleteVenta(Program.idSelected);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }
        private void EliminarProductoVendido()
        {
            ProductoVendidoNegocio.DeleteProductoVendido(Program.idSelected);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }

        private void CrearUsuario()
        {
            string nombre = this.textBox2.Text;
            string apellido = this.textBox3.Text;
            string nombreUsuario = this.textBox4.Text;
            string password = this.textBox5.Text;
            string email = this.textBox6.Text;

            UsuarioNegocio.PostUsuario(nombre, apellido, nombreUsuario, password, email);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }
        private void CrearProducto()
        {
            string descripcion = this.textBox2.Text;
            int costo = int.Parse(this.textBox3.Text);
            int precioVenta = int.Parse(this.textBox4.Text);
            int stock = int.Parse(this.textBox5.Text);
            int idUsuario = int.Parse(this.textBox6.Text);

            ProductoNegocio.PostProducto(descripcion, costo, precioVenta, stock, idUsuario);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }
        private void CrearVenta()
        {
            string comentarios = this.textBox3.Text;
            int idUsuario = int.Parse(this.textBox4.Text);

            VentaNegocio.PostVenta(comentarios, idUsuario);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }
        private void CrearProductoVendido()
        {
            int stock = int.Parse(this.textBox3.Text);
            int idProducto = int.Parse(this.textBox4.Text);
            int idVenta = int.Parse(this.textBox5.Text);

            ProductoVendidoNegocio.PostProductoVendido(stock, idProducto, idVenta);

            this.Close();
            Inicio.grilla.Show();
            Inicio.grilla.cargarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.modificar)
            {
                Program.modificar = false;
                switch (Program.instancia)
                {
                    case "Usuario":
                        ModificarUsuario();
                        break;
                    case "Producto":
                        ModificarProducto();
                        break;
                    case "Venta":
                        ModificarVenta();
                        break;
                    case "ProductoVendido":
                        ModificarProductoVendido();
                        break;
                }
            }
            else if (Program.idSelected > 0)
            {
                switch (Program.instancia)
                {
                    case "Usuario":
                        EliminarUsuario();
                        break;
                    case "Producto":
                        EliminarProducto();
                        break;
                    case "Venta":
                        EliminarVenta();
                        break;
                    case "ProductoVendido":
                        EliminarProductoVendido();
                        break;
                }
            }
            else
            {
                switch (Program.instancia)
                {
                    case "Usuario":
                        CrearUsuario();
                        break;
                    case "Producto":
                        CrearProducto();
                        break;
                    case "Venta":
                        CrearVenta();
                        break;
                    case "ProductoVendido":
                        CrearProductoVendido();
                        break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.modificar = true;
            this.textBox3.ReadOnly = false;
            this.textBox4.ReadOnly = false;
            this.button2.Text = "Guardar";
            this.button3.Hide();
            switch (Program.instancia)
            {
                case "Usuario":
                    this.textBox2.ReadOnly = false;
                    this.textBox5.ReadOnly = false;
                    this.textBox6.ReadOnly = false;
                    break;
                case "Producto":
                    this.textBox2.ReadOnly = false;
                    this.textBox5.ReadOnly = false;
                    this.textBox6.ReadOnly = false;
                    break;
                case "ProductoVendido":
                    this.textBox5.ReadOnly = false;
                    break;
                default:
                    break;
            }
        }
    }
}
