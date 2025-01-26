using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.DB.Data.Entidades
{
    public class PeliculaActor
    {
        // Al ser una relacion n-m necesitamos una PK compuesta, lo configuramos en el Context

        public int ActorId { get; set; }
        public int PeliculaId { get; set; }
        public Actor? Actor { get; set; }
        public Pelicula? Pelicula { get; set; }
        public string? Personaje { get; set; }
        public int Orden { get; set; }

    }
}
