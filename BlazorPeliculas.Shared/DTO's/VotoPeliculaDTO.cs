using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.DTO_s
{
    public class VotoPeliculaDTO
    {
        public int Id { get; set; }
        public int Voto { get; set; }
        public DateTime? FechaVoto { get; set; }
        public int PeliculaId { get; set; }
        public PeliculaDTO? Pelicula { get; set; }
    }
}
