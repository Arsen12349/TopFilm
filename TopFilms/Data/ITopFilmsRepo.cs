using System.Collections.Generic;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface ITopFilmsRepo
    {
        bool SaveChanges();

        IEnumerable<Films> GetAllCommands();
        Films GetCommandById(int id);
        void CreateCommand(Films cmd);
        void UpdateCommand(Films cmd);
        void DeleteCommand(Films cmd);
    }
}
