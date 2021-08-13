using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopFilms.Models;

namespace TopFilms.Data
{
    public class SqlTopFilmsRepo : ITopFilmsRepo
    {
        private readonly TopFilmsContext _context;

        public SqlTopFilmsRepo(TopFilmsContext context) 
        {
            _context = context;
        }

        public void CreateCommand(Films cmd)
        {
            if(cmd == null) 
            {
                throw new ArgumentNullException(nameof(cmd));           
            }

            _context.Films.Add(cmd);
        }

        public IEnumerable<Films> GetAllCommands()
        {
            return _context.Films.ToList();
        }

        public Films GetCommandById(int id)
        {
            return _context.Films.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
