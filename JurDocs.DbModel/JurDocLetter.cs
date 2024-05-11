using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JurDocs.DbModel
{
    /// <summary>
    /// Письмо
    /// </summary>
    public class JurDocLetter
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOutgoing { get; set; }
        public DateTime? DateIncoming { get; set; }
        public string? NumberOutgoing { get; set; }
        public string? NumberIncoming { get; set; }
        public int ExecutivePerson { get; set; }

        public bool IsDeleted { get; set; } = false;

        class Configuration : IEntityTypeConfiguration<JurDocLetter>
        {
            public void Configure(EntityTypeBuilder<JurDocLetter> builder)
            {
            }
        }
    }
}
