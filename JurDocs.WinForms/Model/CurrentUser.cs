namespace JurDocsWinForms.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrentUser
    {
        public Guid Token { get; set; }
        public string? UserName { get; set; }
        public string TempDir { get; set; } = string.Empty;
    }
}
