using JurDocs.Client;

namespace JurDocs.Core.Views
{
    public interface IProjectListView
    {
        void ChangeCurrentProject(JurDocProject currentProject);
        Task UpdateProjectList();
    }
}