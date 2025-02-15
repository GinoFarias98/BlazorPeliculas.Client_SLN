namespace BlazorPeliculas.Client.Servicios
{
    public class HttpRespuesta<O>
    {
        public HttpRespuesta(O respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            this.httpResponseMessage = httpResponseMessage;
        }

        public O Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage httpResponseMessage { get; set; }


        public async Task<string> ObtenerError()
        {

			if (!Error)
			{
				return "";
			}

			var statusCode = httpResponseMessage.StatusCode;

            switch (statusCode)
            {
				case System.Net.HttpStatusCode.BadRequest:
					return httpResponseMessage.Content.ReadAsStringAsync().ToString()!;
				//                    return "Error, no se puede procesar la información";
				case System.Net.HttpStatusCode.Unauthorized:
					return "Error, no tiene permisos para realizar esta acción";
				case System.Net.HttpStatusCode.Forbidden:
					return "Error, no tiene autorización a ejecutar este proceso";
				case System.Net.HttpStatusCode.NotFound:
					return "Error, dirección no encontrado";
				default:
					return httpResponseMessage.Content.ReadAsStringAsync().Result;
            }
        }         
    }
}
