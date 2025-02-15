
namespace BlazorPeliculas.Client.Servicios
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<O>> Get<O>(string url);

        Task<HttpRespuesta<object>> Post<O>(string url, O entidad);

        Task<HttpRespuesta<object>> Put<O>(string url, O entidad);

        Task<HttpRespuesta<object>> Delete(string url);

    }
}