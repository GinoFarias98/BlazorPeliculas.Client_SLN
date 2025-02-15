
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace BlazorPeliculas.Client.Servicios
{
    public class HttpServicio : IHttpServicio
    {
        private readonly HttpClient http;

        public HttpServicio(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpRespuesta<O>> Get<O>(string url)
        {
            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerealizar<O>(response);
                return new HttpRespuesta<O>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<O>(default, true, response);
            }
        }

        public async Task<HttpRespuesta<object>> Post<O>(string url, O entidad)  // "O" lo que se envia, "object" lo que recibo.
        {
            var EntSerializada = JsonSerializer.Serialize(entidad);
            var EnviarJSON = new StringContent(EntSerializada, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(url, EnviarJSON);

            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerealizar<object>(response);
                return new HttpRespuesta<object>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<object>(default, true, response);
            }
		}

        public async Task<HttpRespuesta<object>> Put<O>(string url, O entidad)
        {
            var enviarJson = JsonSerializer.Serialize(entidad);

            var enviarContent = new StringContent(enviarJson,
                                Encoding.UTF8,
                                "application/json");

            var response = await http.PutAsync(url, enviarContent);
            if (response.IsSuccessStatusCode)
            {
                return new HttpRespuesta<object>(null, false, response);
            }
            else
            {
                return new HttpRespuesta<object>(default, true, response);
            }
        }

        public async Task<HttpRespuesta<object>> Delete(string url)
        {
            var respuestaHttp = await http.DeleteAsync(url);

            if (!respuestaHttp.IsSuccessStatusCode)
            {
                var error = await respuestaHttp.Content.ReadAsStringAsync();
                return new HttpRespuesta<object>(null, true, respuestaHttp); // Pasar el HttpResponseMessage directamente.
            }

            return new HttpRespuesta<object>(null, false, respuestaHttp);
        }


        private async Task<O> DesSerealizar<O>(HttpResponseMessage response)
        {
            var respuesta = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<O>(respuesta, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
