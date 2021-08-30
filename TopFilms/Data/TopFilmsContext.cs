using Microsoft.EntityFrameworkCore;
using TopFilms.Models;

namespace TopFilms.Data
{
    public class TopFilmsContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }

        public TopFilmsContext(DbContextOptions<TopFilmsContext> opt) : base(opt) 
        {
        
        }
    }   
}
