using ApiMovies.Models;

namespace ApiMovies.Interfaces
{
    public interface IRepositoryPelicula
    {
        Task<IEnumerable<Pelicula>> GetAllAsync();
        Task<Pelicula?> GetByIdAsync(int id);
        Task addMovie(Pelicula pelicula);
        Task UpdateMovie(Pelicula pelicula);
        Task DeleteMovie(int id);
    }
}
