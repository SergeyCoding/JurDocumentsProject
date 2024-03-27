using Microsoft.EntityFrameworkCore;

namespace DbModel
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsDbContext : DbContext
    {
        private const string _cs = @"Data Source=D:\TFS\JurDocumentsProject\Data\DB\jur-docs.db";

        //public DbSet<User> Users { get; set; } = null!;
        //public DbSet<Token> Tokens { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_cs);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof( JurDocsDbContext).Assembly);
        }
    }
}
