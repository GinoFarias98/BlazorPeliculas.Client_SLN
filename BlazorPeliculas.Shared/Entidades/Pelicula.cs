using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.Entidades
{
	public class Pelicula
	{
		public int Id { get; set; }
		[Required]
		public string Nombre { get; set; } = null!;
		public string? Resumen { get; set; }
		public bool EnCartelera { get; set; }
		public string? Trailer { get; set; }
		public DateTime? Lanzamiento { get; set; }
		public string? Poster { get; set; } = null!;
		public List<GeneroPelicula> GererosPelicula { get; set; } = new List<GeneroPelicula>();	
		public string? NombreCorto
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
