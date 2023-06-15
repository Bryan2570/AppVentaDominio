using Microsoft.AspNetCore.Mvc;


using AppVentaDominio;
using AppVentaAplicaciones.Servicios;
using AppVenta.InfraestructuraDatos.Contextos;
using AppVenta.InfraestructuraDatos.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppVenta.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        //Creamos funcion que retorna un productosevricio
        ProductoServicio CrearServicio() {         
            VentaContexto db = new VentaContexto();
            ProductoRepositorio repo = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(repo);
            return servicio;               
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorId(id));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            servicio.Agregar(producto);
            return Ok("Agregado satisfactoriamente!!!");
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            producto.productoId = id;
            servicio.Editar(producto);
            return Ok("Editado correctamente!!!");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado correctamente!!!");
        }
    }
}
