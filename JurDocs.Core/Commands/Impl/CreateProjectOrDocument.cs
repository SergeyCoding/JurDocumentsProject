using JurDocs.Core.Commands.Documents;
using JurDocs.Core.Commands.Projects;
using JurDocs.Core.Constants;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class CreateProjectOrDocument(AppState state,
                                           ICreateProject createProject,
                                           ICreateDocument createDocument) : ICreateProjectOrDocument
    {
        /// <summary>
        /// 
        /// </summary>
        public async Task ExecuteAsync(IMainView mainView)
        {
            if (mainView == null)
                throw new Exception();

            if (state.CurrentPage == AppPage.Проект)
            {
                await createProject.ExecuteAsync(mainView);

                return;
            }

            if (state.CurrentPage == AppPage.Письмо)
            {
                await createDocument.ExecuteAsync(mainView);
                return;
            }
        }
    }
}