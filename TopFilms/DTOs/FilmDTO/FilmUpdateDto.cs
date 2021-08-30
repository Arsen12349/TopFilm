using System.ComponentModel.DataAnnotations;

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
        public string Genres { get; set; }

        [Required]
        public int DirectorId { get; set; }

        public IList<ActorDTO> Actors { get; set; }
    }
}
