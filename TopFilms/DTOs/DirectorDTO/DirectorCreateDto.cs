using System.ComponentModel.DataAnnotations;

namespace TopFilms.Dtos
{
    public class DirectorCreateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }
    }
}
