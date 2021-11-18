using System.Collections.Generic;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface IBaseRepo
    {
        IEnumerable<BaseDirector> GetAll();
        BaseDirector GetBaseId(int id);
    }
}
