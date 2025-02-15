namespace BlazorPeliculas.Client.Repositorios
{
    public class HttpResponseWrapper<T>
    {

        public HttpResponseWrapper(T? respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Respuesta { get; }
        public bool Error { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

    }
}
