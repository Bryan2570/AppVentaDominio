using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVentaDominio;
using AppVentaDominio.Interfaces.Repositorios;
using AppVentaAplicaciones.Interfaces;

namespace AppVentaAplicaciones.Servicios
{
    public class ProductoServicio : IServicioBase<Producto, Guid>
    {
        private readonly IRepositoriBase<Producto, Guid> repoProducto;

        public ProductoServicio(IRepositoriBase<Producto, Guid> _repoProducto)
        {
            repoProducto = _repoProducto;
        }


        //valido si la entidad es un valor nulo
        public Producto Agregar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("EL PRODUCTO ES REQUERIDO");

            var resultProduct = repoProducto.Agregar(entidad);
            repoProducto.GuardarTodosLosCambios();
            return resultProduct;
        }

        public void Editar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("EL PRODUCTO ES REQUERIDO PARA EDITAR");
            repoProducto.Editar(entidad);
            repoProducto.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoProducto.Eliminar(entidadId);
            repoProducto.GuardarTodosLosCambios();
        }

        public List<Producto> Listar()
        {
            return repoProducto.Listar();
        }

        public Producto SeleccionarPorId(Guid entidadId)
        {
            return repoProducto.SeleccionarPorId(entidadId);
        }
    }
}
