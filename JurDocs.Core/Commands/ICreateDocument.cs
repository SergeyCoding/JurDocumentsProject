using JurDocs.Core.Views;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICreateDocument
    {
        Task CreateDocumentAsync(IMainView mainView);
    }
}