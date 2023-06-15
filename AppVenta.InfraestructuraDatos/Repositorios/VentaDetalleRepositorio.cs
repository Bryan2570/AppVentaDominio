using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVentaDominio;
using AppVentaDominio.Interfaces.Repositorios;
using AppVenta.InfraestructuraDatos.Contextos;

namespace AppVenta.InfraestructuraDatos.Repositorios
{
    public class VentaDetalleRepositorio : IRepositorioDetalle<VentaDetalle, Guid>
    {
        private VentaContexto db;

        public VentaDetalleRepositorio(VentaContexto _db)
        {
            db = _db;
        }

        public VentaDetalle Agregar(VentaDetalle entidad)
        {
            db.VentaDetalles.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }
    }
}
