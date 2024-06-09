using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class ProductoData
    {
        private string connectionString;

        public ProductoData()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";
        }
        public static Producto GetProductById(int id)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto WHERE Id=@id";
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("id", id);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int productId = Convert.ToInt32(reader[0]);
                        string descripcion = reader.GetString(1);
                        int costo = Convert.ToInt32(reader[2]);
                        int precioVenta = Convert.ToInt32(reader[3]);
                        int stock = Convert.ToInt32(reader[4]);
                        int idUsuario = Convert.ToInt32(reader[5]);

                        Producto producto = new Producto(productId, descripcion, costo, precioVenta, stock, idUsuario);
                        return producto;
                    }
                    throw new Exception("El Id no fue encontrado");
                }
                catch (Exception ex)
                {
                    throw new Exception("El Id no fue encontrado");
                }
            }
        }
        public static List<Producto> GetProducts()
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            List<Producto> products = new List<Producto>();
            string query = "SELECT * FROM Producto";
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
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(reader[0]);
                                producto.Descripcion = reader.GetString(1);
                                producto.Costo = Convert.ToInt32(reader[2]);
                                producto.PrecioVenta = Convert.ToInt32(reader[3]);
                                producto.Stock = Convert.ToInt32(reader[4]);
                                producto.IdUsuario = Convert.ToInt32(reader[5]);

                                products.Add(producto);
                            }
                        }
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                return products;
            }
        }
        public static bool CreateProduct(Producto producto)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Producto(Descripciones,Costo,PrecioVenta,Stock,IdUsuario) values(@descripcion,@costo,@precioVenta,@stock,@idUsuario)";
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("Costo", producto.Costo);
                    command.Parameters.AddWithValue("PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("Stock", producto.Stock);
                    command.Parameters.AddWithValue("IdUsuario", producto.IdUsuario);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool UpdateProduct(int id, Producto producto)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Producto SET Descripciones = @descripcion,Costo=@costo,PrecioVenta=@precioVenta,Stock=@stock,IdUsuario=@idUsuario WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("Costo", producto.Costo);
                    command.Parameters.AddWithValue("PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("Stock", producto.Stock);
                    command.Parameters.AddWithValue("IdUsuario", producto.IdUsuario);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static bool DeleteProduct(int productId)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Producto WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.Parameters.AddWithValue("id", productId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
