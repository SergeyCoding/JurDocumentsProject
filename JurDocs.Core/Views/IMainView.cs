using JurDocs.Core.Model;
using JurDocs.WinForms.ViewModel;

namespace JurDocs.Core.Views
{
    public interface IMainView
    {
        void OpenDocEditor(EditedDocData docData);
        void OpenProjectEditor(EditedProjectData projectData);
    }
}