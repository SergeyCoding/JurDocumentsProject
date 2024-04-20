using JurDocs.Client;
using JurDocs.Core.Constants;
using JurDocs.Core.States;

namespace JurDocs.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class GetState
    {
        public AppPage GetCurrentPage => AppState.Instance.CurrentPage;
        public JurDocProject GetCurrentProject => AppState.Instance.CurrentProject;
    }
}
