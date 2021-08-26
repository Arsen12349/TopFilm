using System.Collections.Generic;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface IFilmsRepo
    {
        bool SaveChanges();

        IEnumerable<Films> GetAll();
        Films GetFilmId(int id);
        void Create(Films cmd);
        void Update(Films cmd);
        void Delete(Films cmd);
    }
}
