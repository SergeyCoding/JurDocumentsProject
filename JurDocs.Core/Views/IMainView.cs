using JurDocs.Core.Model;

namespace JurDocs.Core.Views
{
    public interface IMainView
    {
        void OpenDocEditor(EditedDocData docData);
        void OpenProjectEditor(EditedProjectData projectData);
    }
}