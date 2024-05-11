using JurDocs.Core.Model;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Projects
{
    /// <summary>
    /// Закрыть редактирование проекта
    /// </summary>
    public interface ICloseProject
    {
        Task ExecuteAsync(IProjectListView view, EditedProjectData editedProjectData);
    }
}