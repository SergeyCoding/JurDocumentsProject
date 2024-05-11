using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Projects
{
    /// <summary>
    /// Создать проект
    /// </summary>
    public interface ICreateProject
    {
        Task ExecuteAsync(IMainView mainView);
    }
}