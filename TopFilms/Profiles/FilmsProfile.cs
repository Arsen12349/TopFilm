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
            CreateMap<Film, FilmReadDto>();
            CreateMap<FilmCreateDto, Film>();
            CreateMap<FilmUpdateDto, Film>();
            CreateMap<Film, FilmUpdateDto>();
        }
    }
}
