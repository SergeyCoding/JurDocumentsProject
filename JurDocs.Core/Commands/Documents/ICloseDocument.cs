using JurDocs.Core.Model;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Documents
{
    /// <summary>
    /// Закрыть редактирование проекта
    /// </summary>
    public interface ICloseDocument
    {
        Task ExecuteAsync(IDocEditor view, EditedDocData data);
    }
}
