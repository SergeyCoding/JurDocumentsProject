using JurDocs.Common.EnumTypes;

namespace JurDocs.Core.Model
{
    public class EditedDocData
    {
        public OpenEditorType OpenType { get; set; } = OpenEditorType.None;
        public CloseEditorType CloseType { get; set; } = CloseEditorType.None;

        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        public int Id { get; set; }
        public JurDocType DocType { get; set; }
        public string? DocName { get; set; }

        public DateTime? DateOutgoing { get; set; }

        public DateTime? DateIncoming { get; set; }

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

        /// <summary>
        /// Отправители списком
        /// </summary>
        public List<string> SenderList { get; set; } = [];

        /// <summary>
        /// Получатели списком
        /// </summary>
        public List<string> RecipientList { get; set; } = [];
    }
}