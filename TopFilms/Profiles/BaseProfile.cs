using AutoMapper;
using TopFilms.DTOs;
using TopFilms.Models;

namespace TopFilms.Profiles
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            //Source -> Target
            CreateMap<BaseDirector, BaseDto>() ;
            CreateMap<BaseDto, BaseDirector>();
        }
    }
}
