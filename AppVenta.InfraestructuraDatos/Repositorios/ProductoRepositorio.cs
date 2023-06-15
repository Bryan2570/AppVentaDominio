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
    public class ProductoRepositorio : IRepositoriBase<Producto, Guid>
    {

        private VentaContexto db;

        public ProductoRepositorio(VentaContexto _db)
        {
            db = _db;
        }

        public Producto Agregar(Producto entidad)
        {
            entidad.productoId = Guid.NewGuid();
            db.Productos.Add(entidad);
            return entidad;
        }

        public void Editar(Producto entidad)
        {
            var productoSeleccionado = db.Productos.Where(c => c.productoId == entidad.productoId).FirstOrDefault();
            if (productoSeleccionado != null) { 
            
                productoSeleccionado.productoName = entidad.productoName;
                productoSeleccionado.productoDesc = entidad.productoDesc;
                productoSeleccionado.costo = entidad.costo;
                productoSeleccionado.precio = entidad.precio;
                productoSeleccionado.cantidadEnStock = entidad.cantidadEnStock;

                db.Entry(productoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //metodo Entry para enmarcar el modificado
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var productoSeleccionado = db.Productos.Where(c => c.productoId == entidadId).FirstOrDefault();
            if (productoSeleccionado != null)
            {
                db.Productos.Remove(productoSeleccionado);          
            }
        }

        public void GuardarTodosLosCambios()
        {
           db.SaveChanges();
        }

        public List<Producto> Listar()
        {
            return db.Productos.ToList();
        }

        public Producto SeleccionarPorId(Guid entidadId)
        {
            var productoSeleccionado = db.Productos.Where(c => c.productoId == entidadId).FirstOrDefault();
            return productoSeleccionado;
        }
    }
}
