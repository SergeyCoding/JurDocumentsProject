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
                mainView.OpenDocEditor();
                return;
                //using (var scope = Core.Container().BeginLifetimeScope())
                //{
                //    var createNewDoc = scope.Resolve<ICreateNewDoc>();

                //    Form f = new AddNewDoc { ViewModel = await ViewModel.CreateNewDoc() };
                //    ProgramHelpers.MoveWindowToCenterScreen(f);
                //    f.ShowDialog(this);
                //}
            }

            //var persons = (await state.Client.PersonAsync()).Result;

            //var newProject = (await state.Client.ProjectPOSTAsync()).Result;

            //state.CurrentProject = newProject;

            //var ownerId = newProject.OwnerId;

            //var createProjectViewModel = new CreateProjectViewModel((Client.JurDocsClient?)state.Client)
            //{
            //    ProjectId = newProject.Id,
            //    ProjectName = newProject.Name,
            //    ProjectFullName = newProject.FullName,
            //    ProjectOwnerId = newProject.OwnerId,
            //    ProjectOwnerName = persons.FirstOrDefault(x => x.PersonId == ownerId)!.PersonName,
            //};


            //return createProjectViewModel;
        }
    }
}