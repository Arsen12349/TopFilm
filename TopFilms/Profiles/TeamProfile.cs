using AutoMapper;
using TopFilms.Dtos;
using TopFilms.Models;

namespace TopFilms.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            //Source -> Target
            CreateMap<Team, TeamReadDto>();
            CreateMap<TeamCreateDto, Team>();
            CreateMap<TeamUpdateDto, Team>();
            CreateMap<Team, TeamUpdateDto>();
        }
    }
}
