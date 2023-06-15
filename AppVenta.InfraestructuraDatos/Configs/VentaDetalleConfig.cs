using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AppVentaDominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVenta.InfraestructuraDatos.Configs
{
    class VentaDetalleConfig : IEntityTypeConfiguration<VentaDetalle>
    {
        public void Configure(EntityTypeBuilder<VentaDetalle> builder)
        {
            builder.ToTable("tblVentasDetalles");
            builder.HasKey(c => new { c.productoId, c.ventaId});//llave primaria compuesta: que se cre  de la llave foranea de venta y de producto

            //configuramos relaciones de manera explicita
            builder
                .HasOne(detalle => detalle.Producto)   //HasOne => definimos que venta detalle tenga un producto
                .WithMany(producto => producto.VentaDetalles);  //definimos que productoVenta tenga muchos VentasDetalles

            builder
                .HasOne(detalle => detalle.Venta)
                .WithMany(venta => venta.ventaDetalles);
        }
    }
}
