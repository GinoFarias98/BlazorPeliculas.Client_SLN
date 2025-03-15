using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.DTO_s
{
    public class PeliculaActorDTO
    {
        public int ActorId { get; set; }
        public int PeliculaId { get; set; }
        public ActorDTO? Actor { get; set; }
        public PeliculaDTO? Pelicula { get; set; }
        public string? Personaje { get; set; }
        public int Orden { get; set; }
    }
}
