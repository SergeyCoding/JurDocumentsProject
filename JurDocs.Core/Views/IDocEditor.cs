using JurDocs.WinForms.ViewModel;

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