using System.Collections.Generic;
using TopFilms.Models;

namespace TopFilms.Data
{
    public interface IActorRepo
    {
        bool SaveChanges();

        IEnumerable<Actor> GetAll();
        Actor GetId(int id);
        void Create(Actor cmd);
        void Update(Actor cmd);
        void Delete(Actor cmd);
    }
}
