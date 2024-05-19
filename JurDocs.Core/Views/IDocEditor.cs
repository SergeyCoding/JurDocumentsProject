using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;

namespace JurDocs.Core.Views
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocEditor
    {
        CloseEditorType CloseType { get; set; }

        void SetData(EditedDocData data);
        EditedDocData GetData();
    }
}