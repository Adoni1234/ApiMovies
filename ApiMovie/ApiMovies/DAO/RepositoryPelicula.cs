using ApiMovies.Context;
using ApiMovies.Interfaces;
using ApiMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMovies.DAO
{
    public class RepositoryPelicula : IRepositoryPelicula
    {
        private readonly ContextDb _context;

        public RepositoryPelicula(ContextDb context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Pelicula>> GetAllAsync()
        {
            return await _context.Peliculas.ToListAsync();
        }

        public async Task<Pelicula?> GetByIdAsync(int id) { 
            return await _context.Peliculas.FindAsync(id);
        }

        public async Task addMovie(Pelicula pelicula) { 
          _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovie(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovie(int id)
        {
            var datos = await _context.Peliculas.FindAsync(id);

            if (datos != null)
            {
                _context.Peliculas.Remove(datos);
                await _context.SaveChangesAsync();

            }
        }
    }
}
