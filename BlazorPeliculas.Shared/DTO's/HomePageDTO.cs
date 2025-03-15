using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.DTO_s
{
    public class HomePageDTO
    {
        public List<PeliculaDTO>? PeliculasEnCartelera { get; set; }
        public List<PeliculaDTO>? ProximosEstrenos { get; set; }
    }

}
