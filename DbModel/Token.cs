using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DbModel
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
