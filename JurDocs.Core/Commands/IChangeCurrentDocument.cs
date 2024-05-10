namespace JurDocs.Core.Commands

{
    /// <summary>
    /// Изменить текущий документ
    /// </summary>
    public interface IChangeCurrentDocument
    {
        Task ExecuteAsync(int docId);
    }
}