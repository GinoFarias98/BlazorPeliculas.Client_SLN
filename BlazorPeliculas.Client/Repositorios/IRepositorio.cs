using BlazorPeliculas.Shared.Entidades;

namespace BlazorPeliculas.Client.Repositorios
{
    public interface IRepositorio
    {
        public List<Pelicula> ObtenerPeliculas();
    }
}
