using JurDocs.Client;
using JurDocs.Core.Model;

namespace JurDocs.Core.Commands
{
    public interface ISaveRights
    {
        Task ExecuteAsync(JurDocProject project, List<UserRight> rights);
    }
}