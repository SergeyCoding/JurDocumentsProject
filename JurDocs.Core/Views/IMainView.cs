using JurDocs.Core.Model;

namespace JurDocs.Core.Views
{
    public interface IMainView
    {
        void OpenDocEditor();
        void OpenProjectEditor(EditedProjectData projDto);
    }
}