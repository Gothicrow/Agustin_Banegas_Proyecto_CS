using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public class UsuarioData
    {
        private string connectionString;

        public UsuarioData()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";
        }
        public static Usuario GetUserById(int id)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuario WHERE Id=@id";
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("id", id);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader[0]);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        string nombreUsuario = reader.GetString(3);
                        string password = reader.GetString(4);
                        string email = reader.GetString(5);

                        Usuario usuario = new Usuario(userId, nombre, apellido, nombreUsuario, password, email);
                        return usuario;
                    }
                    throw new Exception("El Id no fue encontrado");
                }
                catch(Exception ex)
                {
                    throw new Exception("El Id no fue encontrado");
                }
            }
        }
        public static List<Usuario> GetUsers()
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            List<Usuario> users = new List<Usuario>();
            string query = "SELECT * FROM Usuario";
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
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(reader[0]);
                                usuario.Nombre = reader.GetString(1);
                                usuario.Apellido = reader.GetString(2);
                                usuario.NombreUsuario = reader.GetString(3);
                                usuario.Password = reader.GetString(4);
                                usuario.Email = reader.GetString(5);

                                users.Add(usuario);
                            }
                        }
                    }
                }
                return users;
            }
            catch
            {
                return users;
            }
        }
        public static bool CreateUser(Usuario usuario)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuario(Nombre,Apellido,NombreUsuario,Contraseña,Mail) values(@nombre,@apellido,@nombreUsuario,@password,@email)";
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("Apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("NombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("Password", usuario.Password);
                    command.Parameters.AddWithValue("Email", usuario.Email);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool UpdateUser(int id, Usuario usuario)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre,Apellido=@apellido,NombreUsuario=@nombreUsuario,Contraseña=@password,Mail=@email WHERE Id = @id";
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("Apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("NombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("Password", usuario.Password);
                    command.Parameters.AddWithValue("Email", usuario.Email);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool DeleteUser(int userId)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=true";
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuario WHERE Id = @id";
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.Parameters.AddWithValue("id", userId);

                    return command.ExecuteNonQuery() > 0;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
