using LozhkaGames.Models;
using Microsoft.EntityFrameworkCore;

namespace LozhkaGames
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }

        public DbSet<Game> games { get; set; }
        
        public DbSet<SteamKey> keys { get; set; }
    }
}
