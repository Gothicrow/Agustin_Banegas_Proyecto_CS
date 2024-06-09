using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class ProductoVendidoNegocio
    {
        public static ProductoVendido GetProductoVendido(int id)
        {
            return ProductoVendidoData.GetProductoVendidoById(id);
        }
        public static List<ProductoVendido> GetProductosVendidos()
        {
            return ProductoVendidoData.GetProductosVendidos();
        }
        public static bool PostProductoVendido(int stock, int idProducto, int idVenta)
        {
            ProductoVendido productoVendido = new ProductoVendido(stock, idProducto, idVenta);
            return ProductoVendidoData.CreateProductoVendido(productoVendido);
        }
        public static bool UpdateProductoVendido(int id, int stock, int idProducto, int idVenta)
        {
            ProductoVendido productoVendido = new ProductoVendido(stock, idProducto, idVenta);
            return ProductoVendidoData.UpdateProductoVendido(id, productoVendido);
        }
        public static bool DeleteProductoVendido(int id)
        {
            return ProductoVendidoData.DeleteProductoVendido(id);
        }
    }
}
