using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.DB.Data.Entidades
{
    public class GeneroPelicula
    {
        // Al ser una relacion n-m necesitamos una PK compuesta, lo configuramos en el Context

        public int PeliculaId { get; set; }
        public int GeneroId { get; set; }
        public Genero? Genero { get; set; }
        public Pelicula? Pelicula { get; set; }
    }
}
