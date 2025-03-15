using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.DTO_s
{
    public class GeneroPeliculaDTO
    {
        public int PeliculaId { get; set; }
        public int GeneroId { get; set; }
        public GeneroDTO? Genero { get; set; }
        public PeliculaDTO? Pelicula { get; set; }
    }
}
