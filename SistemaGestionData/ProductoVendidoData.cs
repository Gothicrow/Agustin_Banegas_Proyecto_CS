using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class ProductoVendidoData
    {
        private string connectionString;

        public ProductoVendidoData()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";
        }
        public static ProductoVendido GetProductoVendidoById(int id)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM ProductoVendido WHERE Id=@id";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("id", id);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int productoVendidoId = Convert.ToInt32(reader[0]);
                        int productId = Convert.ToInt32(reader[1]);
                        int stock = Convert.ToInt32(reader[2]);
                        int idVenta = Convert.ToInt32(reader[3]);

                        ProductoVendido productoVendido = new ProductoVendido(id, productId, stock, idVenta);
                        return productoVendido;
                    }
                    throw new Exception("El Id no fue encontrado");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("El Id no fue encontrado");
            }
        }
        public static List<ProductoVendido> GetProductosVendidos()
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            string query = "SELECT * FROM ProductoVendido";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(reader[0]);
                                productoVendido.Stock = Convert.ToInt32(reader[1]);
                                productoVendido.IdProducto = Convert.ToInt32(reader[2]);
                                productoVendido.IdVenta = Convert.ToInt32(reader[3]);

                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }
                }
                return productosVendidos;
            }
            catch(Exception ex)
            {
                return productosVendidos;
            }
        }
        public static bool CreateProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ProductoVendido(Stock,IdProducto,IdVenta) values(@stock,@idProducto,@idVenta)";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("Stock", productoVendido.Stock);
                    command.Parameters.AddWithValue("IdProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("IdVenta", productoVendido.IdVenta);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool UpdateProductoVendido(int id, ProductoVendido productoVendido)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ProductoVendido SET Stock=@stock,IdProducto=@idProducto,IdVenta=@idVenta WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("Stock", productoVendido.Stock);
                    command.Parameters.AddWithValue("IdProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("IdVenta", productoVendido.IdVenta);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static bool DeleteProductoVendido(int productoVendidoId)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM ProductoVendido WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.Parameters.AddWithValue("id", productoVendidoId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
