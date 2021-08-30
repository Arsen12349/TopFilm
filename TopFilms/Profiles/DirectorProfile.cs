using AutoMapper;
using TopFilms.Dtos;
using TopFilms.Models;

namespace TopFilms.Profiles
{
    public class DirectorProfile : Profile
    {
        public DirectorProfile()
        {
            //Source -> Target
            CreateMap<Director, DirectorReadDto>();
            CreateMap<DirectorCreateDto, Director>();
            CreateMap<DirectorUpdateDto, Director>();
            CreateMap<Director, DirectorUpdateDto>();
        }
    }
}
