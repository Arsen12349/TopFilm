using Microsoft.EntityFrameworkCore;
using TopFilms.Models;

namespace TopFilms.Data
{
    public class TopFilmsContext : DbContext
    {
        public DbSet<Films> Films { get; set; }
        public DbSet<Team> Team { get; set; }

        public TopFilmsContext(DbContextOptions<TopFilmsContext> opt) : base(opt) 
        {
        
        }

    }

    
}
