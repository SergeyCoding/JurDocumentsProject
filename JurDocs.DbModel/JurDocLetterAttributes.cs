using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JurDocs.DbModel
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocLetterAttributes
    {
        public int Id { get; set; }
        public int JurDocLetterId { get; set; }
        public string? AttributeType { get; set; }
        public string? AttributeValue { get; set; }

        class Configuration : IEntityTypeConfiguration<JurDocLetterAttributes>
        {
            public void Configure(EntityTypeBuilder<JurDocLetterAttributes> builder)
            {
            }
        }
    }
}
