namespace ApiMovies.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;  
        public int AnioEstreno { get; set; } 
        public string Genero { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public double Calificacion { get; set; }
        public string CartelUrl { get; set; } = string.Empty;
        public string TrailerUrl { get; set; } = string.Empty;
    }

}
