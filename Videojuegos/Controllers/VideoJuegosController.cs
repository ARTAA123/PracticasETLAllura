using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Caching.Memory;
using VideojuegosWebAPI.Data;
using VideojuegosWebAPI.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideojuegosWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoJuegosController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public VideoJuegosController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }



        // GET: api/<VideoJuegosController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<VideoJuegos> listaVideojuegos = new List<VideoJuegos>();
            Memoria datos = new Memoria(_memoryCache);
            listaVideojuegos =datos.ObtenerVideoJuegos();
            return Ok(listaVideojuegos);
        }

        // GET api/<VideoJuegosController>/5
        [HttpGet("{id}")]
        public ActionResult<VideoJuegos> Get(int id)
        {
            VideoJuegos videojuego = new VideoJuegos();
            Memoria datos = new Memoria(_memoryCache);
            videojuego = datos.ObtenerVideoJuegoID(id);
            return Ok(videojuego);
        }

        // POST api/<VideoJuegosController>
        [HttpPost]
        public ActionResult Post([FromBody] VideoJuegos value)
        {
            Memoria datos = new Memoria(_memoryCache);
            datos.GuardarVideoJuego(value);
            return Ok(value);
        }

        // PUT api/<VideoJuegosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] VideoJuegos value)
        {
            Memoria datos = new Memoria(_memoryCache);
            datos.EditarVideoJuego(value, id);
            return Ok(value);
        }

        // DELETE api/<VideoJuegosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(VideoJuegos videoJuego, int id)
        {
            Memoria datos = new Memoria(_memoryCache);
            datos.BorrarVideoJuego(videoJuego, id);
            return Ok(videoJuego);
        }


        // DELETE api/<VideoJuegosController>/5
        [HttpDelete("{id}/*{id_Tipo_Juego}")]
        public ActionResult Delete(VideoJuegos videoJuego, int id, int id_Tipo_Juego)
        {
            Memoria datos = new Memoria(_memoryCache);
            datos.BorrarTipoVideoJuegoLista(videoJuego, id, id_Tipo_Juego);
            return Ok(videoJuego);
        }
    }
}
