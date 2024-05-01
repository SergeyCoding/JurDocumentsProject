using JurDocs.Client;
using JurDocs.Core.Model;

namespace JurDocs.Core.Commands
{
    public interface ISaveProject
    {
        Task ExecuteAsync(JurDocProject project);
        Task ExecuteAsync(EditedProjectData project);
    }
}