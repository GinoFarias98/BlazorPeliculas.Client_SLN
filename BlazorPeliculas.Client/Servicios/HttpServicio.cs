
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

        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerealizar<T>(response);
                return new HttpRespuesta<T>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<T>(default!, true, response);
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
                return new HttpRespuesta<object>(default!, true, response);
            }
        }

        public async Task<HttpRespuesta<object>> Put<T>(string url, T entidad)
        {
            var enviarJson = JsonSerializer.Serialize(entidad);

            var enviarContent = new StringContent(enviarJson,
                                Encoding.UTF8,
                                "application/json");

            var response = await http.PutAsync(url, enviarContent);
            if (response.IsSuccessStatusCode)
            {
                return new HttpRespuesta<object>(null!, false, response);
            }
            else
            {
                return new HttpRespuesta<object>(default!, true, response);
            }
        }

        public async Task<HttpRespuesta<object>> Delete(string url)
        {
            var respuestaHttp = await http.DeleteAsync(url);

            if (!respuestaHttp.IsSuccessStatusCode)
            {
                var error = await respuestaHttp.Content.ReadAsStringAsync();
                return new HttpRespuesta<object>(null!, true, respuestaHttp); // Pasar el HttpResponseMessage directamente.
            }

            return new HttpRespuesta<object>(null!, false, respuestaHttp);
        }


        private async Task<T> DesSerealizar<T>(HttpResponseMessage response)
        {
            var respuesta = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respuesta, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        }
    }
}
