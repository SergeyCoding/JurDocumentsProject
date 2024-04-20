using JurDocs.Core.States;

namespace JurDocs.Core
{
    public class AppStateContext
    {
        internal AppState State => GetState.AppState();
    }
}
