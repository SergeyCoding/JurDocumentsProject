using JurDocs.Core.Commands.Documents;
using JurDocs.Core.Commands.Projects;
using JurDocs.Core.Constants;
using JurDocs.Core.DI;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// Открыть проект или документ
    /// </summary>
    class OpenProjectOrDocument(AppState state,
                                IOpenProject openProject,
                                IOpenDocument openDocument) : IOpenProjectOrDocument
    {
        public async Task ExecuteAsync(IMainView mainView)
        {
            if (mainView == null)
                throw new Exception();

            if (state.CurrentPage == AppPage.Проект)
            {
                await openProject.ExecuteAsync(mainView);
                return;
            }

            if (state.CurrentPage == AppPage.Письмо)
            {
                await openDocument.ExecuteAsync(mainView);
                return;
            }

        }
    }
}