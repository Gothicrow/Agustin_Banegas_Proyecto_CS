using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class VentaData
    {
        private string connectionString;

        public VentaData()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";
        }
        public static Venta GetVentaById(int id)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Venta WHERE Id=@id";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("id", id);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int ventaId = Convert.ToInt32(reader[0]);
                        string comentarios = reader.GetString(1);
                        int idUsuario = Convert.ToInt32(reader[2]);

                        Venta venta = new Venta(ventaId, comentarios, idUsuario);
                        return venta;
                    }
                    throw new Exception("El Id no fue encontrado");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("El Id no fue encontrado");
            }
        }
        public static List<Venta> GetVentas()
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            List<Venta> ventas = new List<Venta>();
            string query = "SELECT * FROM Venta";
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
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(reader[0]);
                                venta.Comentarios = reader.GetString(1);
                                venta.IdUsuario = Convert.ToInt32(reader[2]);

                                ventas.Add(venta);
                            }
                        }
                    }
                }
                return ventas;
            }
            catch (Exception ex)
            {
                return ventas;
            }
        }
        public static bool CreateVenta(Venta venta)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Venta(Comentarios,IdUsuario) values(@comentarios,@idUsuario)";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("Comentarios", venta.Comentarios);
                    command.Parameters.AddWithValue("IdUsuario", venta.IdUsuario);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static bool UpdateVenta(int id, Venta venta)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Venta SET Comentarios=@comentarios,IdUsuario=@idusuario WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("Comentarios", venta.Comentarios);
                    command.Parameters.AddWithValue("IdUsuario", venta.IdUsuario);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool DeleteVenta(int ventaId)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Venta WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.Parameters.AddWithValue("id", ventaId);

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
