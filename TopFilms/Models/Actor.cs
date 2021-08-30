using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TopFilms.Models
{

    public class Actor
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        public virtual ICollection <Film> Films { get; set; }
    }
}
