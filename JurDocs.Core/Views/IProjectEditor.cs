
using JurDocs.Core.Model;

namespace JurDocs.Core.Views
{
    public interface IProjectEditor
    {
        EditedProjectData GetData();
        void SetData(EditedProjectData projectData);
    }
}