using AbbyWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Data
{
    public class AbbyDbContext:DbContext
    {

        public AbbyDbContext(DbContextOptions<AbbyDbContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }   

    }
}
