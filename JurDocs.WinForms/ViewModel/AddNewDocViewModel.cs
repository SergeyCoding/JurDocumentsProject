using JurDocs.Client;

namespace JurDocs.WinForms.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class AddNewDocViewModel(JurDocsClient client)
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

        public void SaveDoc()
        {

        }
    }
}
