using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Database.Migrations
{
    public class LibContextFactory : IDesignTimeDbContextFactory<LibContext>
    {
        public LibContext CreateDbContext(string[] args)
        {
            string databaseString = "Server=localhost:5432;Database=library;Username=postgres;Password=postgres";
            
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                databaseString = args[0];
            }

            var dbContextFactory = new PooledDbContextFactory<LibContext>(
                new DbContextOptionsBuilder<LibContext>()
                .UseNpgsql(databaseString, options =>
                {
                    options.MigrationsAssembly("LibraryApp.Database.Migrations");
                })
                .UseSnakeCaseNamingConvention()
                .Options);

            return dbContextFactory.CreateDbContext();
        }
    }
}
