using JurDocs.Core.Views;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// Создание проекта
    /// </summary>
    public interface ICreateProject
    {
        Task CreateNewProject(IMainView mainView);
    }
}