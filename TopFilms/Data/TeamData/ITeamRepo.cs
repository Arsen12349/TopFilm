using System.Collections.Generic;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface ITeamRepo
    {
        bool SaveChanges();

        IEnumerable<Team> GetAll();
        Team GetId(int id);
        void Create(Team cmd);
        void Update(Team cmd);
        void Delete(Team cmd);
    }
}
