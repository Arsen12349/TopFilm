using System;
using System.Collections.Generic;
using System.Linq;
using TopFilms.Models;

namespace TopFilms.Data
{
    public class ActorRepo : IActorRepo
    {
        private readonly TopFilmsContext _context;

        public ActorRepo(TopFilmsContext context)
        {
            _context = context;
        }

        public void Create(Actor cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
        }

        public void Delete(Actor cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Actors.Remove(cmd);
        }

        public IEnumerable<Actor> GetAll()
        {
            return _context.Actors.ToList();
        }

        public Actor GetId(int id)
        {
            return _context.Actors.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Actor cmd)
        {
            //Nothing
        }
    }
}
