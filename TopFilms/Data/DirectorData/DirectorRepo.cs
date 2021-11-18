using System;
using System.Collections.Generic;
using System.Linq;
using TopFilms.Models;

namespace TopFilms.Data
{
    public class DirectorRepo : IDirectorRepo
    {
        private readonly TopFilmsContext _context;

        public DirectorRepo(TopFilmsContext context)
        {
            _context = context;
        }

        public void Create(Director cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
        }

        public void Delete(Director cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Directors.Remove(cmd);
        }

        public IEnumerable<Director> GetAll()
        {
            return _context.Directors.ToList();
        }

        public Director GetBaseId(int id)
        {
            throw new NotImplementedException();
        }

        public Director GetDirectorId(int id)
        {
            return _context.Directors.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Director cmd)
        {
            //Nothing
        }
    }
}
