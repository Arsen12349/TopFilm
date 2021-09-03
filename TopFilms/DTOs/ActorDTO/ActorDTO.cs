using System.ComponentModel.DataAnnotations;

namespace TopFilms.DTOs.ActorDTO
{
    public class ActorDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }
    }
}
