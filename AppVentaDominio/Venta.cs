﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentaDominio
{
    public class Venta
    {

        public Guid ventaId { get; set; }
        public long numeroVenta { get; set; }
        public DateTime fecha { get; set; }
        public string concepto { get; set; }

        public decimal subtotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }
        public bool anulado { get; set; } = false;

        //agregamos un objeto de tipo List
        public List<VentaDetalle>? ventaDetalles { get; set; }
    }
}
