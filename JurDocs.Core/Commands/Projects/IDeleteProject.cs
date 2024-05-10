namespace JurDocs.Core.Commands.Projects
{
    /// <summary>
    /// Создание документа текущего типа
    /// </summary>
    public interface IDeleteProject
    {
        Task ExecuteAsync(int projectId);
    }
}