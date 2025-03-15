using BlazorPeliculas.DB.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.DTO_s
{
    public class PeliculaActualizacionDTO
    {
        public PeliculaDTO? Pelicula { get; set; }

        public List<ActorDTO> Actores { get; set; } = new List<ActorDTO>();

        public List<GeneroDTO> GenerosSeleccionados { get; set; } = new List<GeneroDTO>();

        public List<GeneroDTO> GenerosNoSeleccionados { get; set; } = new List<GeneroDTO>();

    }
}
