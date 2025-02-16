using BlazorPeliculas.DB.Data;
using BlazorPeliculas.DB.Data.Entidades;
using BlazorPeliculas.Server.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPeliculas.Server.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly Context context;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "personas";

        public ActoresController(Context context, IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.almacenadorArchivos = almacenadorArchivos;
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
    }

}
