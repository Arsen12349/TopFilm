using AutoMapper;
using TopFilms.DTOs.ActorDTO;
using TopFilms.Models;

namespace TopFilms.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            //Source -> Target
            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>();
            //CreateMap<Actor, ActorReadDto>();
            //CreateMap<ActorUpdateDto, Actor>();
            //CreateMap<Actor, ActorUpdateDto>();
        }
    }
}
