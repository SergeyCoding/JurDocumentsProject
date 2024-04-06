using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbModel
{
    public class ProjectRights
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? DocType { get; set; }
        public int UserId { get; set; }

        class Configuration : IEntityTypeConfiguration<ProjectRights>
        {
            public void Configure(EntityTypeBuilder<ProjectRights> builder)
            {
            }
        }
    }

}
