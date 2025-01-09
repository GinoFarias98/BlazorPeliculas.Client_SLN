using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.Entidades
{
	public class Pelicula
	{
		public string Nombre { get; set; } = null!;
		public DateTime FechaLanzamiento { get; set; }
		public string Poster { get; set; } = null!;
		public string NombreCorto
		{
			get
			{
				if(string.IsNullOrEmpty(Nombre))
				{
					return null;
				}

				if(Nombre.Length > 60)
				{
					return Nombre.Substring(0, 60) + "...";
				}
				else
				{
					return Nombre;
				}
			}
		}
	}
}
