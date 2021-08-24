﻿using System.ComponentModel.DataAnnotations;

namespace TopFilms.Dtos
{
    public class FilmsCreateDto
    {
        [Required]
        public string NameFilm { get; set; }

        [Required]
        public int YearFilm { get; set; }

        [Required]
        public string AboutFilm { get; set; }

        [Required]
        public int Budget { get; set; }

        [Required]
        public int Gross { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Genres { get; set; }

        [Required]
        public string Team { get; set; }
    }
}