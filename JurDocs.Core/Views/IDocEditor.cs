using JurDocs.Client;

namespace JurDocs.Core.Views
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocEditor
    {
        void SetData(LetterDocument data);
        LetterDocument GetData();
    }
}