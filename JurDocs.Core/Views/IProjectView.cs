namespace JurDocs.Core.Views
{
    public interface IProjectView
    {
        Task UpdateProjectList();
        Task SetCurrentProject(int projectId);
    }
}