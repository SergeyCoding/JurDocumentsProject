namespace JurDocs.Core.View
{
    public interface IProjectView
    {
        Task UpdateProjectList();
        Task SetCurrentProject(int projectId);
    }
}