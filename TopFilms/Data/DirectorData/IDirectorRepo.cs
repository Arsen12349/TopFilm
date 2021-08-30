using System.Collections.Generic;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface IDirectorRepo
    {
        bool SaveChanges();

        IEnumerable<Director> GetAll();
        Director GetId(int id);
        void Create(Director cmd);
        void Update(Director cmd);
        void Delete(Director cmd);
        void Create(Actor commandModel);
    }
}
