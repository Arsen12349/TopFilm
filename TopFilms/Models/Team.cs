using System.ComponentModel.DataAnnotations.Schema;

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
