using JurDocs.Common.EnumTypes;
using JurDocs.Core.Commands.Rights;
using JurDocs.Core.Model;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Projects.Impl
{
    /// <summary>
    /// 
    /// </summary>
    class CloseProject(IDeleteProject deleteProject,
                       ISaveProject saveProject,
                       ISaveRights saveRights,
                       IChangeCurrentProject changeCurrentProject) : ICloseProject
    {
        public async Task ExecuteAsync(IProjectListView view, EditedProjectData editedProjectData)
        {
            var cancel = editedProjectData.CloseType == CloseEditorType.Cancel;
            if (cancel && editedProjectData.OpenType == OpenEditorType.Create)
            {
                await deleteProject.ExecuteAsync(editedProjectData.ProjectId);
                await view.UpdateProjectList();
                return;
            }

            if (cancel && editedProjectData.OpenType == OpenEditorType.Edit)
            {
                return;
            }

            if (cancel)
                return;

            if (editedProjectData.OpenType == OpenEditorType.Create)
            {
                await saveProject.ExecuteAsync(editedProjectData);
                await saveRights.ExecuteAsync(editedProjectData);
                await view.UpdateProjectList();
                await changeCurrentProject.ExecuteAsync(view, editedProjectData.ProjectId);
            }

            if (editedProjectData.OpenType == OpenEditorType.Edit)
            {
                await saveProject.ExecuteAsync(editedProjectData);
                await saveRights.ExecuteAsync(editedProjectData);
                await view.UpdateProjectList();
                await changeCurrentProject.ExecuteAsync(view, editedProjectData.ProjectId);
            }
        }
    }
}