using System.ComponentModel.DataAnnotations;

namespace TopFilms.Dtos
{
    public class TeamUpdateDto
    {
        [Required]
        public string NamePerson { get; set; }

        [Required]
        public string FunctionPerson { get; set; }

        [Required]
        public string AboutPerson { get; set; }
    }
}
