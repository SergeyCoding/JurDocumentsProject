using JurDocs.Core.States;

namespace JurDocs.Core.Commands.Projects.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class DeleteProject(AppState state) : IDeleteProject
    {
        public async Task ExecuteAsync(int projectId)
        {
            await state.Client.ProjectDELETEAsync(projectId);
        }
    }
}