
namespace JurDocs.Core.Commands
{
    public interface IChangeCurrentProject
    {
        Task ExecuteAsync(int projectId);
    }
}