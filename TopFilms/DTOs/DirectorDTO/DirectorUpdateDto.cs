using System.ComponentModel.DataAnnotations;

namespace TopFilms.Dtos
{
    public class DirectorUpdateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }
    }
}
