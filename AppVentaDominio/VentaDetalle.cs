using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentaDominio
{
    public class VentaDetalle
    {
        public Guid productoId { get; set; }
        public Guid ventaId { get; set; }

        public decimal costoUnitario { get; set; }

        public decimal precioUnitario { get; set; }
        public decimal cantidadVendida { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }

        //una venta esta asociada a un producto
        public Producto? Producto { get; set; }
        public Venta? Venta { get; set; }

    }
}
