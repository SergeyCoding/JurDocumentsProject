using JurDocs.Client;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class InitApiClient(Guid token)
    {
        public void Execute() => AppState.Instance.Client = JurClientService.JurDocsClientFactory(token);
    }
}
