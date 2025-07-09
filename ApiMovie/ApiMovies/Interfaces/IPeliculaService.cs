using ApiMovies.Models;

namespace ApiMovies.Interfaces
{
    public interface IPeliculaService
    {
        Task<IEnumerable<Pelicula>> ObtenerPeliculas();
        Task<Pelicula?> ObtenerPeliculaPorId(int id);
        Task CrearPelicula(crearPeliculaDTO pelicula);
        Task EditarPelicula(Pelicula pelicula);
        Task EliminarPelicula(int id);
    }
}
