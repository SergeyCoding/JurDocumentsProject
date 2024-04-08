using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JurDocs.DbModel
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsDbContext(IConfiguration configuration) : DbContext()
    {
        private const string _dbName = "JurDocs";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString(_dbName));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JurDocsDbContext).Assembly);
        }
    }
}
