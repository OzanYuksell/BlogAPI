using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data
{
    public class ArticlesAPIDbContext : DbContext
    {
        public ArticlesAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        // EntitiyFrameworkCore da table görevi görecek olan Articles property'si
        public DbSet<Article> Articles { get; set; }
    }
}
