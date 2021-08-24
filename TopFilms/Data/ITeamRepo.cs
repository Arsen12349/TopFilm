using System.Collections.Generic;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface ITeamRepo
    {
        bool SaveChanges();

        IEnumerable<Team> GetAllCommands();
        Team GetCommandById(int id);
        void CreateCommand(Team cmd2);
        void UpdateCommand(Team cmd2);
        void DeleteCommand(Team cmd2);
    }
}
