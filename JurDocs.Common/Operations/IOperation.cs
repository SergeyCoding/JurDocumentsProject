namespace JurDocs.Common.Operations
{
    public interface IOperation<T>
    {
        Task ExecuteAsync(T context);
    }
}
