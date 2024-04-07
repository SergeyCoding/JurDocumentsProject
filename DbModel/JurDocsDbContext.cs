using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DbModel
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsDbContext : DbContext
    {
        private const string _dbName = "JurDocs";

        private readonly IConfiguration _configuration;

        public JurDocsDbContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        public JurDocsDbContext() : base()
        {

            _configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
            {
                ["ConnectionStrings:JurDocs"] = @"Data Source=D:\TFS\JurDocumentsProject\Data\DB\jur-docs.db"
            }!).Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString(_dbName));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JurDocsDbContext).Assembly);
        }
    }
}
