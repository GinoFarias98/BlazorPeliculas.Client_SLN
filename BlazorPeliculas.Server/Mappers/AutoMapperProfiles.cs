using AutoMapper;
using BlazorPeliculas.DB.Data.Entidades;
using BlazorPeliculas.Shared.DTO_s;

namespace BlazorPeliculas.Server.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        //                                       CreateMap<Origen, Destino>     <--- Formato
        public AutoMapperProfiles()
        {
            // Mapers Pelicula

            CreateMap<Pelicula, PeliculaDTO>();

            //Mappers Actor


            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<Actor, Actor>()
                .ForMember(x => x.Foto, option => option.Ignore());

            //Mappers Genero

            CreateMap<Genero, GeneroDTO>().ReverseMap();


            //Mappers GeneroPelicula

            CreateMap<GeneroPelicula, GeneroPeliculaDTO>().ReverseMap();

            //Mappers PeliculaActor

            CreateMap<PeliculaActor, PeliculaActorDTO>().ReverseMap();
        }
    }
}
