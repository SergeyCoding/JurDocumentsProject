using JurDocs.Client;

namespace JurDocs.Core.Commands
{
    public interface ISaveProject
    {
        Task ExecuteAsync(JurDocProject project);
    }
}