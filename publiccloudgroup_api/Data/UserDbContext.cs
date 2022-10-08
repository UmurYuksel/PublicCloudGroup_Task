using Microsoft.EntityFrameworkCore;
using publiccloudgroup_api.Extensions;
using publiccloudgroup_api.Models;

namespace publiccloudgroup_api.Data
{
    public class UserDbContext :DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source= ./Data/UserDb.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedUser();
        }
    }
}
