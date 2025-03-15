using AutoMapper;
using BlazorPeliculas.DB.Data;
using BlazorPeliculas.DB.Data.Entidades;
using BlazorPeliculas.Server.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculas.Server.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly Context context;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly IMapper mapper;
        private readonly string contenedor = "personas";

        public ActoresController(Context context, IAlmacenadorArchivos almacenadorArchivos, IMapper mapper)
        {
            this.context = context;
            this.almacenadorArchivos = almacenadorArchivos;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actores.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor?>> Get(int id)
        {
            var actor = await context.Actores.FirstOrDefaultAsync(actor => actor.Id == id);

            if (actor is null)
            {
                return NotFound();
            }

            return actor;
        }

        //Filtro para actores. Se pasa el parametro TextoBusueda que sera parte del nombre del actor. Si el parametro es nulo se pasa la lista completa.
        [HttpGet("buscar/{TextoBusqueda}")]
        public async Task<ActionResult<List<Actor>>> Get(string TextoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(TextoBusqueda))
            {
                return new List<Actor>();
            }

            //Take(5) para solo tomar los primeros 5 actores y evitar listas muy grandes.

            return await context.Actores.Where(x => x.Nombre.ToLower().Contains(TextoBusqueda))
                .Take(5)
                .ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Actor actor)
        {
            if (!string.IsNullOrWhiteSpace(actor.Foto))
            {
                var fotoActor = Convert.FromBase64String(actor.Foto);
                actor.Foto = await almacenadorArchivos.GuardarArchivo(fotoActor, "jpg", contenedor);
            }

            context.Add(actor);
            await context.SaveChangesAsync();
            return actor.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Actor actor)
        {
            var actorDB = await context.Actores.FirstOrDefaultAsync(a => a.Id == actor.Id);
            if (actorDB is null)
            {
                return NotFound();
            }
            actorDB = mapper.Map(actor, actorDB);

            if (!string.IsNullOrWhiteSpace(actor.Foto))
            {
                var fotoActor = Convert.FromBase64String(actor.Foto);
                actorDB.Foto = await almacenadorArchivos.EditarArchivo(fotoActor, ".jpg",
                    contenedor, actorDB.Foto!);
            }

            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
