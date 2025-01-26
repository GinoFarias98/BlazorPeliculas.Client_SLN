using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorPeliculas.DB.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculas.DB.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // PK compuestas
            modelBuilder.Entity<GeneroPelicula>().HasKey(x => new {x.GeneroId, x.PeliculaId});
            modelBuilder.Entity<PeliculaActor>().HasKey(x => new { x.ActorId, x.PeliculaId });

        }

        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Actor> Actores => Set<Actor>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<GeneroPelicula> GenerosPelicula => Set<GeneroPelicula>();
        public DbSet<PeliculaActor> PeliculasActor => Set<PeliculaActor>();


    }
}
