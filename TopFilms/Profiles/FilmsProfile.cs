using AutoMapper;
using TopFilms.Dtos;
using TopFilms.Models;

namespace TopFilms.Profiles
{
    public class FilmsProfile : Profile
    {
        public FilmsProfile() 
        {
            //Source -> Target
            CreateMap<Films, FilmsReadDto>();
            CreateMap<FilmsCreateDto, Films>();
            CreateMap<FilmsUpdateDto, Films>();
            CreateMap<Films, FilmsUpdateDto>();
        }
    }
}
