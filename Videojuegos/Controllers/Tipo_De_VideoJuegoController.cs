using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using VideojuegosWebAPI.Data;
using VideojuegosWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideojuegosWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tipo_De_VideoJuegoController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public Tipo_De_VideoJuegoController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        // GET: api/<Tipo_De_VideoJuegosController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<Tipo_De_Juego> listaTipoVideojuegos = new List<Tipo_De_Juego>();
            Memoria datos = new Memoria(_memoryCache);
            listaTipoVideojuegos = datos.ObtenerTipoVideoJuegos();
            return Ok(listaTipoVideojuegos);
        }

        // GET api/<Tipo_De_VideoJuegosController>/5
        [HttpGet("{id}")]
        public ActionResult<Tipo_De_Juego> Get(int id)
        {
            Tipo_De_Juego tipoVideojuego = new Tipo_De_Juego();
            Memoria datos = new Memoria(_memoryCache);
            tipoVideojuego = datos.ObtenerTipoVideoJuegoID(id);
            return Ok(tipoVideojuego);
        }

        // POST api/<Tipo_De_VideoJuegosController>
        [HttpPost]
        public ActionResult Post([FromBody] Tipo_De_Juego value)
        {
            Memoria datos = new Memoria(_memoryCache);
            datos.GuardarTipoVideoJuego(value);
            return Ok(value);
        }

        // PUT api/<Tipo_De_VideoJuegosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Tipo_De_Juego value)
        {
            Memoria datos = new Memoria(_memoryCache);
            datos.EditarTipoVideoJuego(value, id);
            return Ok(value);
        }

        // DELETE api/<Tipo_De_VideoJuegosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Tipo_De_Juego tipoVideoJuego, int id)
        {
            Memoria datos = new Memoria(_memoryCache);
            datos.BorrarTipoVideoJuego(tipoVideoJuego, id);
            return Ok(tipoVideoJuego);
        }
    }
}
