using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JurDocs.DbModel
{
    /// <summary>
    /// 
    /// </summary>
    public class Token
    {
        public int Id { get; set; }

        public string? Login { get; set; }
        public Guid Value { get; set; }

        class Configuration : IEntityTypeConfiguration<Token>
        {
            public void Configure(EntityTypeBuilder<Token> builder)
            {
            }
        }

    }
}
