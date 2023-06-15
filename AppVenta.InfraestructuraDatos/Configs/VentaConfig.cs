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
    class VentaConfig : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("tblVenta");
            builder.HasKey(c => c.ventaId);

            builder
                .HasMany(venta => venta.ventaDetalles)
                .WithOne(detalle => detalle.Venta);

        }
    }
}
