using System;
using System.Collections.Generic;
using System.Linq;
using TopFilms.Models;

namespace TopFilms.Data
{
    public class BaseRepo : IBaseRepo
    {
        private readonly TopFilmsContext _context;

        public BaseRepo(TopFilmsContext context)
        {
            _context = context;
        }

    
        public IEnumerable<BaseDirector> GetAll()
        {
            return _context.BaseDirectors.ToList();
        }

        public BaseDirector GetBaseId(int id)
        {
            return _context.BaseDirectors.FirstOrDefault(p => p.Id == id);
        }

    }
}
