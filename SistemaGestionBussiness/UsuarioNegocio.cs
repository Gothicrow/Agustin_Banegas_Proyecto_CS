using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class UsuarioNegocio
    {
        public static Usuario GetUsuario(int id)
        {
            return UsuarioData.GetUserById(id);
        }
        public static List<Usuario> GetUsuarios()
        {
            return UsuarioData.GetUsers();
        }
        public static bool PostUsuario(string nombre, string apellido, string nombreUsuario, string password, string email)
        {
            Usuario usuario = new Usuario(nombre, apellido, nombreUsuario, password, email);
            return UsuarioData.CreateUser(usuario);
        }
        public static bool UpdateUsuario(int id, string nombre, string apellido, string nombreUsuario, string password, string email)
        {
            Usuario usuario = new Usuario(nombre, apellido, nombreUsuario, password, email);
            return UsuarioData.UpdateUser(id, usuario);
        }
        public static bool DeleteUsuario(int id)
        {
            return UsuarioData.DeleteUser(id);
        }
    }
}
