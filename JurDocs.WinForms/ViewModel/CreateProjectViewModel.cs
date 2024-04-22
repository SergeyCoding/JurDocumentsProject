
using JurDocs.Client;
using JurDocs.Common.EnumTypes;
using JurDocs.Core.Commands;
using JurDocs.Core.Model;

namespace JurDocs.WinForms.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateProjectViewModel(JurDocsClient client)
    {
        private readonly JurDocsClient _client = client;

        public string ProjectName { get; set; } = string.Empty;
        public string ProjectFullName { get; set; } = string.Empty;
        public int ProjectOwnerId { get; set; }
        public List<UserRight> ProjectRights { get; } = [];
        public List<UserRight> ProjectRights_Справки { get; } = [];
        public List<UserRight> ProjectRights_Выписки { get; } = [];
        public int ProjectId { get; internal set; }
        public string ProjectOwnerName { get; internal set; } = string.Empty;

        internal async Task DeleteProjectAsync()
        {
            await _client.ProjectDELETEAsync(ProjectId);
        }

        internal async Task SaveProjectAsync()
        {

            var project = new JurDocProject
            {
                Id = ProjectId,
                FullName = ProjectFullName,
                IsDeleted = false,
                Name = ProjectName,
                OwnerId = ProjectOwnerId
            };

            var rights = new List<UserRight>();

            foreach (var item in ProjectRights)
            {
                item.DocType = JurDocType.All;
                rights.Add(item);
            }

            foreach (var item in ProjectRights_Справки)
            {
                item.DocType = JurDocType.Справка;
                rights.Add(item);
            }

            foreach (var item in ProjectRights_Выписки)
            {
                item.DocType = JurDocType.Выписка;
                rights.Add(item);
            }

            await new SaveProject(project, rights).ExecuteAsync();
        }
    }
}
