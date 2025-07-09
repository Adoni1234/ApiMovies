using ApiMovies.Context;
using ApiMovies.DAO;
using ApiMovies.Interfaces;
using ApiMovies.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de EF Core
builder.Services.AddDbContext<ContextDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// CORS abierto para desarrollo
builder.Services.AddCors(options =>
{
    options.AddPolicy("ApiMovies", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Inyección de dependencias
builder.Services.AddScoped<IRepositoryPelicula, RepositoryPelicula>();
builder.Services.AddScoped<IPeliculaService, PeliculaService>();

var app = builder.Build();

// Middleware CORS antes de todo
app.UseCors("ApiMovies");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
