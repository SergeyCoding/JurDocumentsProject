using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Documents
{
    /// <summary>
    /// Открыть документ текущего типа
    /// </summary>
    public interface IOpenDocument
    {
        Task ExecuteAsync(IMainView mainView);
    }
}