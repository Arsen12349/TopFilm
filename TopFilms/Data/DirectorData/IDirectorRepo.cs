using System.Collections.Generic;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface IDirectorRepo : IBaseRepo<Director>
    {
        bool SaveChanges();

        void Create(Director cmd);
        void Update(Director cmd);
        void Delete(Director cmd);
    }
}
