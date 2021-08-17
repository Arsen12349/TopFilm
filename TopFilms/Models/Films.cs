using System.ComponentModel.DataAnnotations;

namespace TopFilms.Models
{
    public class Films
    {
        [Key]
        //[Required]
        public int Id { get; set; }

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
