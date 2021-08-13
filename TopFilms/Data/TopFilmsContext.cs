using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopFilms.Models;

namespace TopFilms.Data
{
    public class TopFilmsContext : DbContext
    {
        public TopFilmsContext(DbContextOptions<TopFilmsContext> opt) : base(opt) 
        {
        
        }
        

        public DbSet<Films> Films { get; set; }
    }

    
}
