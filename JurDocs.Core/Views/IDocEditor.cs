using JurDocs.Core.Model;

namespace JurDocs.Core.Views
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocEditor
    {
        void SetData(EditedDocData data);
        EditedDocData GetData();
    }
}