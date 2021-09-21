using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class LibraryManagementSystemDbContextFactory :  IDesignTimeDbContextFactory<LibraryManagementDbContext>
    {
        /*LibraryManagementDbContext IDesignTimeDbContextFactory<LibraryManagementDbContext>.CreateDbContext(string[] args)
        {
            /*IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LibraryManagementDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new LibraryManagementDbContext(builder.Options);#1#


        }*/

        public LibraryManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryManagementDbContext>();
            //optionsBuilder.UseSqlServer(
                //mssql  "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibDb;MultipleActiveResultSets=true;");
                optionsBuilder.UseMySql("server=SERVER;user=USERNAME;password=HASLO;database=DATABASE_NAME",
                    ServerVersion.AutoDetect("server=SERVER;user=USERNAME;password=HASLO;database=DATABASE_NAME"));

                return new LibraryManagementDbContext(optionsBuilder.Options);
        }
    }
}