namespace JurDocs.Core.Commands

{
    /// <summary>
    /// Изменить текущий проект
    /// </summary>
    public interface IChangeCurrentDocument
    {
        Task ExecuteAsync(int docId);
    }
}