using LibraryToDocs.Model;
using DevSnap.CommonLibrary.Extensions;
using LibraryToDocs.Configurations;
using Microsoft.EntityFrameworkCore;
using LibraryToDocs.Mappings;

namespace LibraryToDocs.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var service = CoreSettings.GetService(CoreSettings.Core);
            if (service.Repository.Provider == "SqlServer") options.UseSqlServer(service.Repository.ConnectionString);
            else if (service.Repository.Provider == "MySql")
                options.UseMySql(service.Repository.ConnectionString, new MySqlServerVersion(new Version(8, 0, 21)));
            else throw new Exception("DatabaseType not configured");
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddConfiguration(new UserMap());

        }
    }
}
