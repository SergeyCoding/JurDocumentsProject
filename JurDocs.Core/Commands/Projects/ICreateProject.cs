using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Project
{
    /// <summary>
    /// Создать проект
    /// </summary>
    public interface ICreateProject
    {
        Task CreateNewProject(IMainView mainView);
    }
}