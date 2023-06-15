// See https://aka.ms/new-console-template for more information
using AppVenta.InfraestructuraDatos.Contextos;

Console.WriteLine("Hello, World!");

VentaContexto db = new VentaContexto();
db.Database.EnsureCreated();
Console.WriteLine("Listo!!!");
Console.ReadKey();
