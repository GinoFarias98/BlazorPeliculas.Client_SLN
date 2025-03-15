namespace BlazorPeliculas.Client.Repositorios
{
    //No se usa por que actualmente utilizo los servicios ubicadons en la carpeta Servicios del presente proyecto.
    //En un futuro la carpeta Repositorios de este proyecto sea eliminada

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
