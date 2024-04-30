using Autofac;
using JurDocs.Common.EnumTypes;
using JurDocs.Core.Constants;
using JurDocs.Core.DI;
using JurDocs.Core.Model;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class CreateNewDoc(AppState state) : ICreateDocument
    {
        /// <summary>
        /// 
        /// </summary>
        public async Task ExecuteAsync(IProjectEditor projectEditor, IDocEditor docEditor)
        {
            await Task.CompletedTask;

            if (state.CurrentPage == AppPage.Проект)
            {
                if (projectEditor == null)
                    throw new Exception();

                var createProject = CoreContainer.Get<ICreateProject>();
                createProject?.CreateNewProject(projectEditor);
                return;
            }

            if (state.CurrentPage == AppPage.Письмо)
            {
                if (docEditor == null)
                    throw new Exception();

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