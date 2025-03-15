using AutoMapper;
using BlazorPeliculas.DB.Data;
using BlazorPeliculas.DB.Data.Entidades;
using BlazorPeliculas.Server.Helpers;
using BlazorPeliculas.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculas.Server.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly Context context;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly IMapper mapper;
        private readonly string contenedor = "peliculas";

        public PeliculasController(Context context, IAlmacenadorArchivos almacenadorArchivos, IMapper mapper)
        {
            this.context = context;
            this.almacenadorArchivos = almacenadorArchivos;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<HomePageDTO>> Get()
        {
            var limite = 6;
            var peliculasEnCartelera = await context.Peliculas
                .Where(p => p.EnCartelera).Take(limite)
                .OrderByDescending(p => p.Lanzamiento)
                .ToListAsync();

            var fechaActual = DateTime.Today;
            var proximosEstrenos = await context.Peliculas
                .Where(p => p.Lanzamiento > fechaActual)
                .OrderBy(p => p.Lanzamiento).Take(limite)
                .ToListAsync();

            var resultado = new HomePageDTO()
            {
                PeliculasEnCartelera = mapper.Map<List<PeliculaDTO>>(peliculasEnCartelera),
                ProximosEstrenos = mapper.Map<List<PeliculaDTO>>(proximosEstrenos)
            };

            return resultado;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaVisualizarDTO>> Get(int id)
        {
            var pelicula = await context.Peliculas.Where(p => p.Id == id)
                .Include(p => p.GererosPelicula)
                    .ThenInclude(gp => gp.Genero)
                .Include(p => p.PeliculasActor.OrderBy(pa => pa.Orden))
                    .ThenInclude(pa => pa.Actor)
                .FirstOrDefaultAsync();

            if (pelicula is null)
            {
                return NotFound();
            }

            // Falta Sinstema de Votacion, de momento lo vamos a HardCodear

            var promedioVoto = 4;
            var votoUsuario = 5;

            var oGenero = pelicula.GererosPelicula.Select(gp => gp.Genero!).ToList();
            var oActor = pelicula.PeliculasActor.Select(pa => new Actor
            {
                Nombre = pa.Actor!.Nombre,
                Foto = pa.Actor.Foto,
                Personaje = pa.Personaje,
                Id = pa.ActorId

            }).ToList();


            var modelo = new PeliculaVisualizarDTO();
            modelo.Pelicula = mapper.Map<PeliculaDTO>(pelicula);
            modelo.Generos = mapper.Map<List<GeneroDTO>>(oGenero);
            modelo.Actores = mapper.Map<List<ActorDTO>>(oActor);

            modelo.PromedioVotos = promedioVoto;
            modelo.VotoUsuario = votoUsuario;
            return modelo;

        }

        // Metodo para actualizar Pelicula pero
        // me permite traer la totalidad de Generos
        [HttpGet("actualizar/{id}")]
        public async Task<ActionResult<PeliculaActualizacionDTO>> PutGet(int id)
        {
            var peliculaActionresult = await Get(id); // Este Get devuelve un DTO (VisualizarPeliculaDTO)

            // Si el Get de arriba devuelve not found,
            // dado que la Pelicula podria ser nula,
            // entonces devuelve not found en este metodo 
            if (peliculaActionresult.Result is NotFoundResult)
            {
                return NotFound();
            }

            var peliculaVisualizarDTO = peliculaActionresult.Value;
            var generosSeleccionadosIds = peliculaVisualizarDTO!.Generos!.Select(x => x.Id).ToList(); //Generos de la pelicula seleccionada
            //Selecciono los Generos que no tiene la pelicula, para poder seleccionar solo estos
            var generosNoSeleccionados = await context.Generos
                .Where(x => !generosSeleccionadosIds.Contains(x.Id)).ToListAsync();

            // defino modelo como el DTO que devuelvo
            var modelo = new PeliculaActualizacionDTO();

            //Relleno de manera manual el DTO con la info que obtengo
            modelo.Pelicula = peliculaVisualizarDTO.Pelicula;
            modelo.GenerosNoSeleccionados = mapper.Map<List<GeneroDTO>>(generosNoSeleccionados);
            modelo.GenerosSeleccionados = peliculaVisualizarDTO.Generos!;
            modelo.Actores = peliculaVisualizarDTO.Actores!;

            return modelo;

        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Pelicula pelicula)
        {
            if (!string.IsNullOrWhiteSpace(pelicula.Poster))
            {
                var poster = Convert.FromBase64String(pelicula.Poster);
                pelicula.Poster = await almacenadorArchivos.GuardarArchivo(poster, "jpg", contenedor);
            }

            if (pelicula.PeliculasActor is not null)
            {
                for (int i = 0; i < pelicula.PeliculasActor.Count; i++)
                {
                    pelicula.PeliculasActor[i].Orden = i + 1;
                }
            }

            context.Add(pelicula);
            await context.SaveChangesAsync();
            return pelicula.Id;
        }
    }
}
