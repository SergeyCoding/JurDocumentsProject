using JurDocs.Client;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class ChangeCurrentProject(int projectId)
    {
        public async Task ExecuteAsync()
        {
            if (projectId == 0)
            {
                AppState.Instance.CurrentProject = new JurDocProject { Id = 0 };
            }

            var jurDocProject = (await AppState.Instance.Client.ProjectAllAsync()).Result.First(x => x.Id == projectId);

            AppState.Instance.CurrentProject = jurDocProject;
        }
    }
}
