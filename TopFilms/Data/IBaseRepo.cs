using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopFilms.Data
{
    public interface IBaseRepo<M> 
    {
        IEnumerable<M> GetAll();

        M GetId(int id);

    }
}
