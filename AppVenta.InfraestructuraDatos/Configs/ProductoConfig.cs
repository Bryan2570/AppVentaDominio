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
    class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        { 
            builder.ToTable("tblProductos"); //nombre para la tabla
            builder.HasKey(c => c.productoId); // clave primaria 

            builder
              .HasMany(producto => producto.VentaDetalles)
              .WithOne(detalle => detalle.Producto); //un producto tenga muchas ventas detalles
        }
    }
}
