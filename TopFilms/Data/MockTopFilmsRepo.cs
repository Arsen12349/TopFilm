using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopFilms.Models;

namespace TopFilms.Data
{
    public class MockTopFilmsRepo : ITopFilmsRepo
    {
        public void CreateCommand(Films cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Films> GetAllCommands()
        {
            throw new NotImplementedException();
        }

        public Films GetCommandById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Films cmd)
        {
            throw new NotImplementedException();
        }
    }
}
