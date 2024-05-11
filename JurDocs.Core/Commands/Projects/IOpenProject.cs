using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Projects
{
    /// <summary>
    /// Открыть проект
    /// </summary>
    public interface IOpenProject
    {
        Task ExecuteAsync(IMainView mainView);
    }
}