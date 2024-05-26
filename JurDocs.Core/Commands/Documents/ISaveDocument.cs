using JurDocs.Core.Model;

namespace JurDocs.Core.Commands.Documents
{
    /// <summary>
    /// Сохранить документ текущего типа
    /// </summary>
    public interface ISaveDocument
    {
        Task ExecuteAsync(EditedDocData data);
    }
}