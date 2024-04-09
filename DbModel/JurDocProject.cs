using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JurDocs.DbModel
{
    /// <summary>
    /// Проект
    /// </summary>
    public class JurDocProject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public int OwnerId { get; set; }

        public bool IsDeleted { get; set; } = false;


        class Configuration : IEntityTypeConfiguration<JurDocProject>
        {
            public void Configure(EntityTypeBuilder<JurDocProject> builder)
            {
            }
        }
    }

}
