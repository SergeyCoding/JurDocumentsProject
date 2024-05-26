using JurDocs.Core.Model;

namespace JurDocs.Core.Commands.Documents
{
    /// <summary>
    /// Закрыть редактирование проекта
    /// </summary>
    public interface ICloseDocument
    {
        Task ExecuteAsync( EditedDocData data);
    }
}
