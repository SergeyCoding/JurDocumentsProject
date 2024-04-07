namespace JurDocsWinForms.Model
{
    /// <summary>
    /// 
    /// </summary>
    internal class CurrentUser
    {
        public Guid Token { get; set; }
        public string? UserName { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string TempDir { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
