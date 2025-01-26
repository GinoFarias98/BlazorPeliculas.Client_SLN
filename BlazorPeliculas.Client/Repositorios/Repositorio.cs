using BlazorPeliculas.Shared.Entidades;
using static System.Net.WebRequestMethods;

namespace BlazorPeliculas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public List<Pelicula> ObtenerPeliculas()
        {
            return new List<Pelicula>()
            {
                new Pelicula{Nombre = "Cyberpunk2077",
                    Lanzamiento = new DateTime(2024, 07, 20),
                    Poster = "https://upload.wikimedia.org/wikipedia/en/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg"
                },
                new Pelicula{Nombre = "Terminator",
                    Lanzamiento = new DateTime(1984, 10, 07),
                    Poster="https://upload.wikimedia.org/wikipedia/en/thumb/7/70/Terminator1984movieposter.jpg/220px-Terminator1984movieposter.jpg"
                },
                new Pelicula{Nombre = "Blade Runner 2049",
                    Lanzamiento = new DateTime(2010, 12, 24),
                    Poster = "https://upload.wikimedia.org/wikipedia/en/9/9b/Blade_Runner_2049_poster.png"
                }
            };
        }
    }
}
