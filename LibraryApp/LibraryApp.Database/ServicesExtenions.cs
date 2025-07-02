using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Database
{
    public static class ServicesExtenions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<LibContext>(options =>
            {
                options
                .UseNpgsql(configuration.GetConnectionString("LibraryDatabase"))
                .UseSnakeCaseNamingConvention();
            });
        }
    }
}
