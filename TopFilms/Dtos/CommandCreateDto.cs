using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopFilms.Dtos
{
    public class FilmsCreateDto
    {
        public int Id { get; set; }

        public string NameFilm { get; set; }

        public int YearFilm { get; set; }

        public string AboutFilm { get; set; }

        public int Budget { get; set; }

        public int Gross { get; set; }

        public string Director { get; set; }

        public string Genres { get; set; }
    }
}
