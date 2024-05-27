using JurDocs.Client;
using JurDocs.Core.Constants;
using JurDocs.Core.States;

namespace JurDocs.Core
{
    /// <summary>
    /// 
    /// </summary>
    internal class GetState(AppState state) : IGetState
    {
        public AppPage GetCurrentPage => state.CurrentPage;
        public JurDocProject GetCurrentProject => state.CurrentProject;
        public int GetCurrentDocId => state.CurrentDocumentId;
    }
}
