namespace JurDocs.Core.Model
{
    public class EditedProjectData
    {
        public OpenEditorType OpenType { get; set; } = OpenEditorType.None;
        public CloseEditorType CloseType { get; set; } = CloseEditorType.None;
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectFullName { get; set; } = string.Empty;
        public int ProjectOwnerId { get; set; }
        public string ProjectOwnerName { get; set; } = string.Empty;
        public List<UserRight> ProjectRights { get; } = [];
        public List<UserRight> ProjectRights_Справки { get; } = [];
        public List<UserRight> ProjectRights_Выписки { get; } = [];

        public enum OpenEditorType
        {
            None = 0,
            Create,
            Edit
        }

        public enum CloseEditorType
        {
            None = 0,
            Cancel,
            Save
        }
    }
}