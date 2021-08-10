using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopFilms.Models;

namespace TopFilms.Data
{
    public class MockTopFilmsRepo : ITopFilmsRepo
    {
        public Films GetCommandById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Films> GetCommands()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Films> GetAllCommands()
        {
            throw new NotImplementedException();
        }

        internal object GetAppCommands()
        {
            throw new NotImplementedException();
        }
    }
}
