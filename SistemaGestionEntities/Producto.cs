using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaGestionEntities
{
    public class Producto
    {
        private int id;
        private string descripcion;
        private int costo;
        private int precioVenta;
        private int stock;
        private int idUsuario;

        public Producto() { }
        public Producto(string descripcion, int costo, int precioVenta, int stock, int idUsuario)
        {
            this.descripcion = descripcion;
            this.costo = costo;
            this.precioVenta = precioVenta;
            this.stock = stock;
            this.idUsuario = idUsuario;
        }
        public Producto(int id, string descripcion, int costo, int precioVenta, int stock, int idUsuario) : this(descripcion, costo, precioVenta, stock, idUsuario)
        {
            this.id = id;
        }
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Costo { get => costo; set => costo = value; }
        public int PrecioVenta { get => precioVenta; set => precioVenta = value;}
        public int Stock { get => stock; set => stock = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public override string ToString()
        {
            return $"Id = {this.id} - Descripcion = {this.descripcion} - Costo = {this.costo} - PrecioVenta = {this.precioVenta} - Stock = {this.stock} - IdUsuario = {this.idUsuario}";
        }
    }
}
