using ApiMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMovies.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }

        public DbSet<Pelicula> Peliculas { get; set; }
    }
}
