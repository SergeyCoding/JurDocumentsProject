using JurDocs.Client;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class ChangeCurrentProject(AppState state) : IChangeCurrentProject
    {
        public async Task ExecuteAsync(IProjectListView? projectListView, int projectId)
        {
            if (projectId == 0)
            {
                state.CurrentProject = new JurDocProject { Id = 0 };
                return;
            }

            var jurDocProject = (await state.Client.ProjectAllAsync()).Result.First(x => x.Id == projectId);

            state.CurrentProject = jurDocProject;

            projectListView?.ChangeCurrentProject(state.CurrentProject);
        }
    }
}
