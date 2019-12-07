using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSearchAsp.Models
{
    public class GameAppDbContext : DbContext
    {
        public GameAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
        public  DbSet<Post> Posts { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<GameProduct> GameProducts { get; set; }
    }
}
