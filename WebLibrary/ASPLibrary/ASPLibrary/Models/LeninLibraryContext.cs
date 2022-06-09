using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ASPLibrary.Models
{
    public class LeninLibraryContext:DbContext
    {
        public LeninLibraryContext(DbContextOptions options) :
           base(options)

        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
