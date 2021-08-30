using System.Collections.Generic;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface IFilmRepo
    {
        bool SaveChanges();

        IEnumerable<Film> GetAll();
        Film GetFilmId(int id);
        void Create(Film cmd);
        void Update(Film cmd);
        void Delete(Film cmd);
    }
}
