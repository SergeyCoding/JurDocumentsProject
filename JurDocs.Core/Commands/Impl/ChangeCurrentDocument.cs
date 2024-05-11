using JurDocs.Core.States;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// 
    /// </summary>
    class ChangeCurrentDocument(AppState state) : IChangeCurrentDocument
    {
        public Task ExecuteAsync(int docId)
        {
            state.CurrentDocumentId = docId;
            return Task.CompletedTask;
        }
    }
}