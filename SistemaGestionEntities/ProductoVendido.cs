using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class ProductoVendido
    {
        private int id;
        private int stock;
        private int idProducto;
        private int idVenta;

        public ProductoVendido() { }
        public ProductoVendido(int stock, int idProducto, int idVenta)
        {
            this.stock = stock;
            this.idProducto = idProducto;
            this.idVenta = idVenta;
        }
        public ProductoVendido(int id, int stock, int idProducto, int idVenta) : this(idProducto, stock, idVenta)
        {
            this.id = id;
        }
        public int Id { get => id; set=>id = value; }
        public int Stock { get => stock; set=>stock = value; }
        public int IdProducto { get => idProducto; set=>idProducto = value; }
        public int IdVenta {  get => idVenta; set=>idVenta = value; }
        public override string ToString()
        {
            return $"Id = {this.id} - Stock = {this.stock} - IdProducto = {this.idProducto} - IdVenta = {this.idVenta}";
        }
    }
}
