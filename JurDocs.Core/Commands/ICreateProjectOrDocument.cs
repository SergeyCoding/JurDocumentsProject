using JurDocs.Core.Views;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// Создать проект или документ текущего типа
    /// </summary>
    public interface ICreateProjectOrDocument
    {
        Task ExecuteAsync(IMainView mainView);
        Task ExecuteWithDragDropAsync(IMainView mainView, string fileName);
    }
}