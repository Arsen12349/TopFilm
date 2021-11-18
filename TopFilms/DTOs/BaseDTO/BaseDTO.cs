using System.ComponentModel.DataAnnotations;

namespace TopFilms.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }
    }
}
