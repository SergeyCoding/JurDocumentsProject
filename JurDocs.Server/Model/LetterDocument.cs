using JurDocs.Common.EnumTypes;

namespace JurDocs.Server.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class LetterDocument
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public JurDocType DocType { get; set; }
        public string? Name { get; set; }
        public DateTime DateOutgoing { get; set; }
        public DateTime DateIncoming { get; set; }
        public string? NumberOutgoing { get; set; }
        public string? NumberIncoming { get; set; }
        public int ExecutivePerson { get; set; }

        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Отправитель
        /// </summary>
        public List<string> Sender { get; set; } = [];

        /// <summary>
        /// Получатель
        /// </summary>
        public List<string> Recipient { get; set; } = [];
    }
}
