using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using AppVentaDominio;
using AppVenta.InfraestructuraDatos;
using AppVenta.InfraestructuraDatos.Configs;

namespace AppVenta.InfraestructuraDatos.Contextos
{
    public class VentaContexto :DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer(@"Server=DESKTOP-02KNSKU;Initial Catalog=DBPRUE;Persist Security Info=False;User ID=sa;Password=12345");      
        }

         
        protected override void OnModelCreating(ModelBuilder builder) { 
        
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductoConfig());
            builder.ApplyConfiguration(new VentaConfig());
            builder.ApplyConfiguration(new VentaDetalleConfig());
        
        
        
        }

    }
}
