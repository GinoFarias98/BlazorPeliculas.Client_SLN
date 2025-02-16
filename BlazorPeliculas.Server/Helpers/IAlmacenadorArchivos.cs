namespace BlazorPeliculas.Server.Helpers
{
    public interface IAlmacenadorArchivos
    {
        Task<string> GuardarArchivo(byte[] contenido, string extension, string nombreContenedor); // devuelve string de url del archivo, nombre contenedor es nomenclatura de Azure que es como una carpeta
        Task EliminarArchivo(string ruta, string nombreContenedor); 
        
        //Implementacion por defecto de la interface
        async Task<string> EditarArchivo(byte[] contenido, string extencion, 
            string nombreContenedor, string ruta)
        {
            if (ruta is not null)
            {
               await EliminarArchivo(ruta, nombreContenedor);
            }

           return await GuardarArchivo(contenido, extencion, nombreContenedor);
        }
    }
}
