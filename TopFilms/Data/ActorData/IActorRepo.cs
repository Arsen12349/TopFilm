using System.Collections.Generic;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface IActorRepo : IBaseRepo<Actor>
    {
        bool SaveChanges();

        void Create(Actor cmd);
        void Update(Actor cmd);
        void Delete(Actor cmd);
    }
}
