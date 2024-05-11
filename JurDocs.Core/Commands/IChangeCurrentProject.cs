
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// Изменить текущий проект
    /// </summary>
    public interface IChangeCurrentProject
    {
        Task ExecuteAsync(IProjectListView? projectListView, int projectId);
    }
}