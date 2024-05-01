namespace JurDocs.WinForms.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class EditedDocData
    {
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectFullName { get; set; } = string.Empty;
        public int ProjectOwnerId { get; set; }

        /// <summary>
        /// Отправитель
        /// </summary>
        public List<string> Sender { get; } = [];

        /// <summary>
        /// Получатель
        /// </summary>
        public List<string> Recipient { get; } = [];
    }
}
