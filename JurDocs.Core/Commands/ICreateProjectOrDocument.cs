using JurDocs.Core.Views;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// Создание документа текущего типа
    /// </summary>
    public interface ICreateProjectOrDocument
    {
        Task ExecuteAsync(IMainView mainView);
    }
}