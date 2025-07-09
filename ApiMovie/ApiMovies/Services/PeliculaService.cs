using ApiMovies.Context;
using ApiMovies.DAO;
using ApiMovies.Interfaces;
using ApiMovies.Models;

namespace ApiMovies.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IRepositoryPelicula _rep;

        public PeliculaService(IRepositoryPelicula rep)
        {
            _rep = rep;
        }

       public async Task<IEnumerable<Pelicula>> ObtenerPeliculas(){
            return await _rep.GetAllAsync();
       }
        public async Task<Pelicula?> ObtenerPeliculaPorId(int id)
        {
            return await _rep.GetByIdAsync(id);
        }
        public async Task CrearPelicula(crearPeliculaDTO inputPelicula)
        {
            var pelicula = new Pelicula
            {
                Titulo = inputPelicula.Titulo,
                AnioEstreno = inputPelicula.AnioEstreno,
                Genero = inputPelicula.Genero,
                Director = inputPelicula.Director,
                Calificacion = inputPelicula.Calificacion,
                CartelUrl = inputPelicula.CartelUrl,
                TrailerUrl = inputPelicula.TrailerUrl
            };
            await _rep.addMovie(pelicula);
        }

        public async Task EditarPelicula(Pelicula pelicula)
        {
            await _rep.UpdateMovie(pelicula);
        }
        public async Task EliminarPelicula(int id)
        {
            await _rep.DeleteMovie(id);
        }

    }
}
