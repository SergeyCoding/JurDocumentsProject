namespace JurDocs.Core.Commands
{
    /// <summary>
    /// Инициализация API-client
    /// </summary>
    public interface IInitApiClient
    {
        void Execute(Guid token);
    }
}