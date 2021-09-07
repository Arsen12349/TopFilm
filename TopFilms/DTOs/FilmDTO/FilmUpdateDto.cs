using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TopFilms.DTOs.ActorDTO;

namespace TopFilms.Dtos
{
    public class FilmUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public int Budget { get; set; }

        [Required]
        public int Gross { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public int DirectorId { get; set; }

        public IList<ActorDto> Actors { get; set; }
    }
}
