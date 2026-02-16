using ContentManagement.Application.Common.Interfaces;
using ContentManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ContentManagement.AdminApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IApplicationDatabaseContext>(provider => provider.GetRequiredService<DatabaseContext>());
        }
    }
}
