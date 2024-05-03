using JurDocs.Client;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICreateDocument
    {
        Task ExecuteAsync(IMainView mainView);
    }
}