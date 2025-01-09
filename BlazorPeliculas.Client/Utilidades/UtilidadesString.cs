namespace BlazorPeliculas.Client.Utilidades
{
	public class UtilidadesString
	{
		//la hacemos estatica para usarla sin necesidad de una instancia de la clase.
		public static string transformar(string valor) => valor.ToUpper();
	}
}
