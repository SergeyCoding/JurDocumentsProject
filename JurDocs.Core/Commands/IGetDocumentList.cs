using JurDocs.Client;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// Получить список документов для текущего проекта
    /// </summary>
    public interface IGetDocumentList
    {
        Task<LetterDocument[]> ExecuteAsync();
    }
}
