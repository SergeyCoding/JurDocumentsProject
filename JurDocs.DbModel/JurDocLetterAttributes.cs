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

        public string? AttributeType { get; set; }

        public string? AttributeValue { get; set; }

        public int JurDocLetterId { get; set; }
        public JurDocLetter? Letter { get; set; }

        class Configuration : IEntityTypeConfiguration<JurDocLetterAttributes>
        {
            public void Configure(EntityTypeBuilder<JurDocLetterAttributes> builder)
            {
                builder.HasOne(p => p.Letter)
                    .WithMany(t => t.Attributes)
                    .HasForeignKey(p => p.JurDocLetterId);
            }
        }
    }
}
