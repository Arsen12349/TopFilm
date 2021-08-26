using System;
using System.Collections.Generic;
using System.Linq;
using TopFilms.Models;

namespace TopFilms.Data
{
    public class SqlFilmsRepo : IFilmsRepo
    {
        private readonly TopFilmsContext _context;

        public SqlFilmsRepo(TopFilmsContext context) 
        {
            _context = context;
        }

        public void Create(Films cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Films.Add(cmd);
        }

        public void Delete(Films cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Films.Remove(cmd);
        }

        public IEnumerable<Films> GetAll()
        {
            return _context.Films.ToList();
        }

        public Films GetId(int id)
        {
            return _context.Films.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Films cmd)
        {
            //Nothing
        }
    }
}
