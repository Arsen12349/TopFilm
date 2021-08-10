using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface ITopFilmsRepo
    {
        IEnumerable<Films> GetAllCommands();
        Films GetCommandById(int id);
    }
}
