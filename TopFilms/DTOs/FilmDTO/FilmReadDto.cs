﻿using System.Collections.Generic;
using TopFilms.DTOs.ActorDTO;

namespace TopFilms.Dtos
{
    public class FilmReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string About { get; set; }

        public int Budget { get; set; }

        public int Gross { get; set; }

        public string Genre { get; set; }

        public int DirectorId { get; set; }

        public IList<ActorDto> Actors { get; set; }
    }
}
