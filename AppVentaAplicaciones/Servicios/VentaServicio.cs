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
    public class VentaServicio : IServicioMovimiento<Venta, Guid>
    {
         IRepositorioMovimiento<Venta, Guid> repoVenta;
         IRepositoriBase<Producto, Guid> repoProducto;
         IRepositorioDetalle<VentaDetalle, Guid> repoDetalle;


        public VentaServicio(IRepositorioMovimiento<Venta, Guid> _repoVenta, IRepositoriBase<Producto, Guid> _repoProducto, IRepositorioDetalle<VentaDetalle, Guid> _repoDetalle)
        {
            repoVenta = _repoVenta;
            repoDetalle = _repoDetalle;
            repoProducto = _repoProducto;            
        }

        public Venta Agregar(Venta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("LA VENTA ES REQUERIDO");

            var ventaAgregada = repoVenta.Agregar(entidad);
            entidad.ventaDetalles.ForEach(detalle => {
                var productoSeleccionado = repoProducto.SeleccionarPorId(detalle.productoId);

                if (productoSeleccionado == null)
                    throw new NullReferenceException("usted esta intentando vender un producto que no existe");

                
                detalle.costoUnitario = productoSeleccionado.costo;
                detalle.precioUnitario = productoSeleccionado.precio;
                detalle.cantidadVendida = detalle.cantidadVendida;
                detalle.subtotal = detalle.precioUnitario * detalle.cantidadVendida;
                detalle.impuesto = detalle.subtotal * 15 / 100;
                detalle.total = detalle.subtotal + detalle.impuesto;
                repoDetalle.Agregar(detalle);

                productoSeleccionado.cantidadEnStock = detalle.cantidadVendida;
                repoProducto.Editar(productoSeleccionado);

                entidad.subtotal += detalle.subtotal;
                entidad.impuesto += detalle.impuesto;
                entidad.total += detalle.total;
            });

            repoVenta.GuardarTodosLosCambios();
            return entidad;
        }

        public void Anular(Guid entidadId)
        {
            repoVenta.Anular(entidadId);
            repoVenta.GuardarTodosLosCambios();
        }

        public List<Venta> Listar()
        {
           return repoVenta.Listar();
        }

        public Venta SeleccionarPorId(Guid entidadId)
        {
            return repoVenta.SeleccionarPorId(entidadId);
        }
    }
}
