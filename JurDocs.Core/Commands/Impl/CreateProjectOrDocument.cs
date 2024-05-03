using JurDocs.Core.Constants;
using JurDocs.Core.DI;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class CreateProjectOrDocument(AppState state) : ICreateProjectOrDocument
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

                var createProject = CoreContainer.Get<ICreateProject>();

                await createProject.CreateNewProject(mainView);

                return;
            }

            if (state.CurrentPage == AppPage.Письмо)
            {
                var createDocument = CoreContainer.Get<ICreateDocument>();
                await createDocument.ExecuteAsync();
                return;
            }
        }
    }
}