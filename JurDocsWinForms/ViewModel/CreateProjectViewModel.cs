namespace JurDocs.WinForms.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateProjectViewModel
    {
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectFullName { get; set; } = string.Empty;
        public string ProjectOwner { get; set; } = string.Empty;
        public List<UserRight> ProjectRights { get; } = [];
        public List<UserRight> ProjectRights_Справки { get; } = [];
        public List<UserRight> ProjectRights_Выписки { get; } = [];
    }
}
