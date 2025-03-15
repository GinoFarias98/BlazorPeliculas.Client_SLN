using BlazorPeliculas.DB.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.DTO_s
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Resumen { get; set; }
        public bool EnCartelera { get; set; }
        public string? Trailer { get; set; }
        public DateTime? Lanzamiento { get; set; }
        public string? Poster { get; set; } = null!;
        public List<GeneroPeliculaDTO> GererosPelicula { get; set; } = new List<GeneroPeliculaDTO>();
        public List<PeliculaActorDTO> PeliculasActor { get; set; } = new List<PeliculaActorDTO>();
        public string? NombreCorto
        {
            get
            {
                if (string.IsNullOrEmpty(Nombre))
                {
                    return null;
                }

                if (Nombre.Length > 60)
                {
                    return Nombre.Substring(0, 60) + "...";
                }
                else
                {
                    return Nombre;
                }
            }
        }
    }
}
