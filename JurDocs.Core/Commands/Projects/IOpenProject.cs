using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Project
{
    /// <summary>
    /// Открыть проект
    /// </summary>
    public interface IOpenProject
    {
        Task ExecuteAsync(IMainView mainView);
    }
}