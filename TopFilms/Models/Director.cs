using System.ComponentModel.DataAnnotations;

namespace TopFilms.Models
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }
    }
}
