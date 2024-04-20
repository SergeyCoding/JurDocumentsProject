using JurDocs.Core.States;

namespace JurDocs.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class GetState
    {
        public static AppState state = new();

        internal static AppState AppState() => state;

        public static AppState State => new()
        {
            CurrentPage = state.CurrentPage,
            CurrentProject = state.CurrentProject
        };
    }
}
