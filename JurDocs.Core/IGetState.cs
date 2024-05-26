using JurDocs.Client;
using JurDocs.Core.Constants;

namespace JurDocs.Core
{
    public interface IGetState
    {
        AppPage GetCurrentPage { get; }
        JurDocProject GetCurrentProject { get; }
        int GetCurrentDocId { get; }
    }
}