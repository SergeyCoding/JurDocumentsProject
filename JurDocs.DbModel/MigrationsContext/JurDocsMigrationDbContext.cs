using Microsoft.EntityFrameworkCore;

namespace JurDocs.DbModel.MigrationsContext
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsMigrationDbContext() : DbContext()
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JurDocsMigrationDbContext).Assembly);
        }
    }
}
