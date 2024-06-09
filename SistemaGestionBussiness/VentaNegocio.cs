using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class VentaNegocio
    {
        public static Venta GetVenta(int id)
        {
            return VentaData.GetVentaById(id);
        }
        public static List<Venta> GetVentas()
        {
            return VentaData.GetVentas();
        }
        public static bool PostVenta(string comentarios, int idUsuario)
        {
            Venta venta = new Venta(comentarios, idUsuario);
            return VentaData.CreateVenta(venta);
        }
        public static bool UpdateVenta(int id, string comentarios, int idUsuario)
        {
            Venta venta = new Venta(comentarios, idUsuario);
            return VentaData.UpdateVenta(id, venta);
        }
        public static bool DeleteVenta(int id)
        {
            return VentaData.DeleteVenta(id);
        }
    }
}
