using LibraryApp.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Database
{
    public static class ServicesExtenions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<LibContext>(options =>
            {
                options
                .UseNpgsql(configuration.GetConnectionString("LibraryDatabase"))
                .UseSnakeCaseNamingConvention();
            }, ServiceLifetime.Singleton);

            services.AddTransient<IBookRepository, BookRepository>();
        }
    }
}
