using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class ProductoNegocio
    {
        public static Producto GetProducto(int id)
        {
            return ProductoData.GetProductById(id);
        }
        public static List<Producto> GetProductos()
        {
            return ProductoData.GetProducts();
        }
        public static bool PostProducto(string descripcion, int costo, int precioVenta, int stock, int idUsuario)
        {
            Producto producto = new Producto(descripcion, costo, precioVenta, stock, idUsuario);
            return ProductoData.CreateProduct(producto);
        }
        public static bool UpdateProducto(int id, string descripcion, int costo, int precioVenta, int stock, int idUsuario)
        {
            Producto producto = new Producto(descripcion, costo, precioVenta, stock, idUsuario);
            return ProductoData.UpdateProduct(id, producto);
        }
        public static bool DeleteProducto(int id)
        {
            return ProductoData.DeleteProduct(id);
        }
    }
}
