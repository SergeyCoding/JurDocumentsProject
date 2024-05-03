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
        public string? Name { get; set; }
        public DateTime DateOutgoing { get; set; }
        public DateTime DateIncoming { get; set; }
        public string? NumberOutgoing { get; set; }
        public string? NumberIncoming { get; set; }
        public int ExecutivePerson { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<JurDocLetterAttributes> Attributes { get; set; } = [];

        ///// <summary>
        ///// Отправитель
        ///// </summary>
        //public List<string> Sender { get; } = [];

        ///// <summary>
        ///// Получатель
        ///// </summary>
        //public List<string> Recipient { get; } = [];


        class Configuration : IEntityTypeConfiguration<JurDocLetter>
        {
            public void Configure(EntityTypeBuilder<JurDocLetter> builder)
            {
                builder.HasMany(x => x.Attributes);
            }
        }
    }
}
