using JurDocs.Client;
using JurDocs.Core.Model;

namespace JurDocs.Core.Commands.Rights
{
    /// <summary>
    /// Сохранить права
    /// </summary>
    public interface ISaveRights
    {
        //Task ExecuteAsync(JurDocProject project, List<UserRight> rights);
        Task ExecuteAsync(EditedProjectData project);
    }
}