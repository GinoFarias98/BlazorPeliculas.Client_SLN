using BlazorPeliculas.Shared.DTO_s;
using BlazorPeliculas.Shared.Entidades;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace BlazorPeliculas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient httpClient;

        public Repositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent= new StringContent(enviarJSON, Encoding.UTF8, "aplication/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent); // se hace un post a la url
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp); // encapsulamos la respuesta en el http response
        }

        public List<PeliculaDTO> ObtenerPeliculas()
        {
            return new List<PeliculaDTO>()
            {
                //new Pelicula{Nombre = "Cyberpunk2077",
                //    Lanzamiento = new DateTime(2024, 07, 20),
                //    Poster = "https://upload.wikimedia.org/wikipedia/en/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg"
                //},
                //new Pelicula{Nombre = "Terminator",
                //    Lanzamiento = new DateTime(1984, 10, 07),
                //    Poster="https://upload.wikimedia.org/wikipedia/en/thumb/7/70/Terminator1984movieposter.jpg/220px-Terminator1984movieposter.jpg"
                //},
                //new Pelicula{Nombre = "Blade Runner 2049",
                //    Lanzamiento = new DateTime(2010, 12, 24),
                //    Poster = "https://upload.wikimedia.org/wikipedia/en/9/9b/Blade_Runner_2049_poster.png"
                //}
            };
        }
    }
}
