using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopFilms.Dtos;
using TopFilms.Models;

namespace TopFilms.Profiles
{
    public class FilmsProfile : Profile
    {
        public FilmsProfile() 
        {
            CreateMap<Films, FilmsReadDto>();
        }
    }
}
