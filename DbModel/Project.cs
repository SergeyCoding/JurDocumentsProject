using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbModel
{
    /// <summary>
    /// Проект
    /// </summary>
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public int OwnerId { get; set; }


        class Configuration : IEntityTypeConfiguration<Project>
        {
            public void Configure(EntityTypeBuilder<Project> builder)
            {
            }
        }
    }

}
