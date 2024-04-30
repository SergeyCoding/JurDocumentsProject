using JurDocs.Core.Views;

namespace JurDocs.Core.Commands
{
    public interface ICreateDocument
    {
        Task ExecuteAsync(IProjectEditor projectEditor, IDocEditor docEditor);
    }
}