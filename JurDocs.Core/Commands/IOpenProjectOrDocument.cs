using JurDocs.Core.Views;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// Создание проекта или документа текущего типа
    /// </summary>
    public interface IOpenProjectOrDocument
    {
        Task ExecuteAsync(IMainView mainView);
    }
}