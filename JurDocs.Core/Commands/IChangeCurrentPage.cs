namespace JurDocs.Core.Commands
{
    /// <summary>
    /// Изменить текущую страницу
    /// </summary>
    public interface IChangeCurrentPage
    {
        Task ExecuteAsync(string page);
    }
}