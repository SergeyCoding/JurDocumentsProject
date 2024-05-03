using JurDocs.Client;
using JurDocs.Core.Model;

namespace JurDocs.Core.Views
{
    public interface IMainView
    {
        void OpenDocEditor(LetterDocument docData);
        void OpenProjectEditor(EditedProjectData projectData);
    }
}