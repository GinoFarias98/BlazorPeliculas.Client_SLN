using BlazorPeliculas.Shared.Entidades;
using Microsoft.JSInterop;

namespace BlazorPeliculas.Client.Helpers
{
	public static class IJSRuntimeExtensionMethods
	{
		public static async ValueTask<bool> Confirmar(this IJSRuntime Js, string Mensaje) // Invoco metodo de JS para mostrar un cartel de confirmaion.
		{
			await Js.InvokeVoidAsync("console.log", "prueba de console.log");
			return await Js.InvokeAsync<bool>("confirm", Mensaje);
		}
	}
}
