using JurDocs.Client;
using JurDocs.Core.Commands.Projects;
using JurDocs.Core.Model;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class SaveProject(AppState state) : ISaveProject
    {
        public async Task ExecuteAsync(JurDocProject project)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(project.Name))
                    throw new Exception("Проект должен иметь наименование");

                var _client = state.Client;

                var result = (await _client.ProjectPUTAsync(project)).Result;

                if (result != null && result.Status == "OK")
                {
                    state.CurrentProject = result.Data.First();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ExecuteAsync(EditedProjectData project)
        {
            var jurDocProject = new JurDocProject
            {
                Id = project.ProjectId,
                Name = project.ProjectName,
                FullName = project.ProjectFullName,
                OwnerId = project.ProjectOwnerId,
                IsDeleted = false
            };

            await ExecuteAsync(jurDocProject);
        }
    }
}
