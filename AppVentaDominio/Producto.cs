using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentaDominio
{
    public class Producto
    {
        public Guid productoId { get; set; }

        public string productoName { get; set;}
        public string productoDesc { get; set;}
        public decimal costo { get; set; }  
        public decimal precio { get; set; }
        public decimal cantidadEnStock { get; set; }
        
        public List<VentaDetalle>? VentaDetalles { get; set; }

    }
}
