using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopFilms.Models
{
    
    public class Team
    {
        public int Id { get; set; }

        public string NamePerson { get; set; }

        public string FunctionPerson { get; set; }

        public string AboutPerson { get; set; }


    }
}
