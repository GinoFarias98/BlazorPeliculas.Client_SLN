using BlazorPeliculas.DB.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.DTO_s
{
    public class PeliculaVisualizarDTO
    {
        public PeliculaDTO? Pelicula { get; set; }
        public List<GeneroDTO>? Generos { get; set; }
        public List<ActorDTO>? Actores { get; set; }
        public int VotoUsuario { get; set; }
        public double PromedioVotos { get; set; }
    }
}
