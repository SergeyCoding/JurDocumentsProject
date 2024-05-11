using JurDocs.Common.EnumTypes;
using JurDocs.Core.Commands.Project;
using JurDocs.Core.DI;
using JurDocs.Core.Model;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Projects.Impl
{
    /// <summary>
    /// 
    /// </summary>
    class CloseProject : ICloseProject
    {
        public async Task ExecuteAsync(IProjectListView view, EditedProjectData editedProjectData)
        {
            var cancel = editedProjectData.CloseType == CloseEditorType.Cancel;
            if (cancel && editedProjectData.OpenType == OpenEditorType.Create)
            {
                await CoreContainer.Get<IDeleteProject>().ExecuteAsync(editedProjectData.ProjectId);
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
                await CoreContainer.Get<ISaveProject>().ExecuteAsync(editedProjectData);
                await view.UpdateProjectList();
                await CoreContainer.Get<IChangeCurrentProject>().ExecuteAsync(view, editedProjectData.ProjectId);
            }
        }
    }
}