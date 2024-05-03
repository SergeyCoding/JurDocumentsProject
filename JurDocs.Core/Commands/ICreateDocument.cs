using JurDocs.Core.Views;
using JurDocs.WinForms.ViewModel;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICreateDocument
    {
        Task<EditedDocData> ExecuteAsync();
    }
}