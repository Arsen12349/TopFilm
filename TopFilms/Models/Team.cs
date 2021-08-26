﻿using System.ComponentModel.DataAnnotations;

namespace TopFilms.Models
{

    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string NamePerson { get; set; }

        [Required]
        public string FunctionPerson { get; set; }

        [Required]
        public string AboutPerson { get; set; }

    }
}
