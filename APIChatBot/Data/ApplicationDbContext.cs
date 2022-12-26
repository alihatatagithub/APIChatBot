using APIChatBot.Models;
using Microsoft.EntityFrameworkCore;

namespace APIChatBot.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Tree> Tree { get; set; }
    }
}
