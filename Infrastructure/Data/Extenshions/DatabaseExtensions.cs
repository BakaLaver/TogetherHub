using Domain.Security;
using Infrastructure.Data.DataBaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Extenshions
{
    public static class DatabaseExtensions
    {
        public static async Task InitializeDatabaseAsync(this WebApplication app) 
        {
            using IServiceScope scope = app.Services.CreateScope();
            var dbContext = scope
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>();
            dbContext.Database.MigrateAsync().GetAwaiter().GetResult();

            var manager = scope
                .ServiceProvider
                .GetRequiredService<UserManager<CustomIdentityUser>>();

            await SeedData(dbContext, manager);
        }

        private static async Task SeedData(ApplicationDbContext dbContext, UserManager<CustomIdentityUser> manager)
        {
            await SeedTopicsAsync(dbContext);
            await SeedIdentityUsersAsynck(dbContext, manager);
        }


        private static async Task SeedTopicsAsync(ApplicationDbContext dbContext)
        {
            if(!await dbContext.Topics.AnyAsync()) 
            {
                await dbContext.Topics.AddRangeAsync(InitialData.Topics);
                await dbContext.SaveChangesAsync();
            }
        }
        private static async Task SeedIdentityUsersAsynck(ApplicationDbContext dbContext, UserManager<CustomIdentityUser> manager)
        {
            if (!manager.Users.Any()) 
            {
                foreach(var users in InitialData.identityUsers) 
                {
                    await manager.CreateAsync(users, "1111");
                }
            }
        }
    }
}
