using JurDocs.Client;
using JurDocs.Core.Model;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands
{
    public class SaveProject(JurDocProject project, List<UserRight> rights)
    {
        public async Task ExecuteAsync()
        {
            if (string.IsNullOrWhiteSpace(project.Name))
                throw new Exception("Проект должен иметь наименование");

            var _client = AppState.Instance.Client;

            var swaggerResponse = await _client.ProjectPUTAsync(project);

            //_client.Rig

        }
    }
}
