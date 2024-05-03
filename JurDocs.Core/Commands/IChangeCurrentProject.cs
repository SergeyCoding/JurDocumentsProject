
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands
{
    public interface IChangeCurrentProject
    {
        Task ExecuteAsync(IProjectListView? projectListView, int projectId);
    }
}