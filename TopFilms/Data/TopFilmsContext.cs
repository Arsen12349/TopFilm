using Microsoft.EntityFrameworkCore;
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
