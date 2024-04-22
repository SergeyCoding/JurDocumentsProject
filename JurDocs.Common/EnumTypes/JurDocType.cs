using System.ComponentModel;

namespace JurDocs.Common.EnumTypes
{
    public enum JurDocType
    {
        [Description("Справка")]
        Справка,
        [Description("Выписка")]
        Выписка,
        [Description("Письмо")]
        Письмо,
        [Description("Договор")]
        Договор,
        [Description("All")]
        All,
        [Description("None")]
        None
    }
}
