using JurDocs.Common.EnumTypes;

namespace JurDocs.Core.Model
{
    /// <summary>
    /// Права пользователя
    /// </summary>
    public class UserRight
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public UserRightType Right { get; set; }
        public JurDocType DocType { get; set; } = JurDocType.None;
    }
}
