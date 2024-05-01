using JurDocs.Client;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class InitApiClient(AppState state) : IInitApiClient
    {
        public void Execute(Guid token) => state.Client = JurClientService.JurDocsClientFactory(token);
    }
}
