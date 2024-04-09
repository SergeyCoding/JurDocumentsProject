
using JurDocs.Client;

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
        public string ProjectOwnerName { get; internal set; }=string.Empty;

        internal void SaveProject()
        {
            throw new NotImplementedException();
        }
    }
}
