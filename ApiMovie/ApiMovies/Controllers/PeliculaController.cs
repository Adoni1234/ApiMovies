using ApiMovies.Interfaces;
using ApiMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _ps;

        public PeliculaController(IPeliculaService ps)
        {
            _ps = ps;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _ps.ObtenerPeliculas());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var peli = await _ps.ObtenerPeliculaPorId(id);
            if (peli == null) return NotFound();
            return Ok(peli);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] crearPeliculaDTO pelicula)
        {
            await _ps.CrearPelicula(pelicula);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Pelicula pelicula)
        {
            await _ps.EditarPelicula(pelicula);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ps.EliminarPelicula(id);
            return Ok();
        }
    }
}
