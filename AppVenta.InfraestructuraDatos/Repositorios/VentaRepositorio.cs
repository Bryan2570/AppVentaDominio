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
    public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid>
    {

        private VentaContexto db;


        public VentaRepositorio(VentaContexto _db)
        {
            db = _db;
        }

        public Venta Agregar(Venta entidad)
        {
            entidad.ventaId = Guid.NewGuid();
            db.Ventas.Add(entidad);
            return entidad;
        }

        public void Anular(Guid entidadId)
        {
            var ventaSeleccionada = db.Ventas.Where(v => v.ventaId == entidadId).FirstOrDefault();
            if (ventaSeleccionada == null) {

                throw new NullReferenceException("ESTA INTENTANDO ANULAR UNA VENTA QUE NO EXISTE");

                ventaSeleccionada.anulado = true;
                db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;            
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Venta> Listar()
        {
            return db.Ventas.ToList();
        }

        public Venta SeleccionarPorId(Guid entidadId)
        {
            var ventaSeleccionada = db.Ventas.Where(v => v.ventaId == entidadId).FirstOrDefault();
            return ventaSeleccionada;
        }
    }
}
