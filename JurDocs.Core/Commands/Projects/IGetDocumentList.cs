using JurDocs.Client;

namespace JurDocs.Core.Commands.Projects
{
    /// <summary>
    /// Получить список документов для текущего проекта
    /// </summary>
    public interface IGetDocumentList
    {
        Task<LetterDocument[]> ExecuteAsync();
    }
}
