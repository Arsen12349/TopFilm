using System.ComponentModel.DataAnnotations;

namespace TopFilms.DTOs.ActorDTO
{
    public class ActorUpdateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }
    }
}
