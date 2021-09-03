using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TopFilms.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

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
        public string Genres { get; set; } // can be [enum], how to do this ?

      
        public int DirectorId { get; set; }

        public Director Director { get; set; }

        public virtual ICollection <Actor> Actors { get; set; }
    }
}
