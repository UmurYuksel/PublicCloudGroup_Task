using Microsoft.EntityFrameworkCore;
using publiccloudgroup_api.Models;

namespace publiccloudgroup_api.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "test1@gmail.com", Password = "1234" },
                new User { Id = 2, Email = "test2@gmail.com", Password = "1234" },
                new User { Id = 3, Email = "test3@gmail.com", Password = "1234" },
                new User { Id = 4, Email = "test4@gmail.com", Password = "1234" }
            );
        }
    }
}
