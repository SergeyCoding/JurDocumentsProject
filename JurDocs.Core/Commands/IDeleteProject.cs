namespace JurDocs.Core.Commands
{
    /// <summary>
    /// Создание документа текущего типа
    /// </summary>
    public interface IDeleteProject
    {
        Task ExecuteAsync(int projectId);
    }
}