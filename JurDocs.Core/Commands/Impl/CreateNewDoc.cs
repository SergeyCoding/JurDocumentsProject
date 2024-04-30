using Autofac;
using JurDocs.Core.Constants;
using JurDocs.Core.States;

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
        public async Task ExecuteAsync()
        {
            await Task.CompletedTask;

            if (state.CurrentPage == AppPage.Проект)
            {

                using (var scope = DI.CoreContainer.Get().BeginLifetimeScope())
                {
                    var createProject = scope.Resolve<ICreateProject>();
                }

                //var createProjectViewModel = await ViewModel.CreateNewProject();

                //var f = new CreateProjectForm { ViewModel = createProjectViewModel! };

                //ProgramHelpers.MoveWindowToCenterScreen(f);
                //f.ShowDialog(this);

                //    using (var scope = Views.Container().BeginLifetimeScope())
                //    {
                //        var f = scope.Resolve<CreateProjectForm>();
                //        ProgramHelpers.MoveWindowToCenterScreen(f);
                //        f.ShowDialog(this);
                //    }

                //    await UpdateProjectList();

                //    return;
                //}

                //if (state.CurrentProject == AppPage.Письмо)
                //{

                //    using (var scope = Core.Container().BeginLifetimeScope())
                //    {
                //        var createNewDoc = scope.Resolve<ICreateNewDoc>();

                //        Form f = new AddNewDoc { ViewModel = await ViewModel.CreateNewDoc() };
                //        ProgramHelpers.MoveWindowToCenterScreen(f);
                //        f.ShowDialog(this);
                //    }
                //}

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

                //foreach (var person in persons)
                //{
                //    createProjectViewModel.ProjectRights.Add(new UserRight
                //    {
                //        UserId = person.PersonId,
                //        UserName = person.PersonName,
                //        Right = UserRightType.NotAllow
                //    });

                //    createProjectViewModel.ProjectRights_Справки.Add(new UserRight
                //    {
                //        UserId = person.PersonId,
                //        UserName = person.PersonName,
                //        Right = UserRightType.NotAllow
                //    });

                //    createProjectViewModel.ProjectRights_Выписки.Add(new UserRight
                //    {
                //        UserId = person.PersonId,
                //        UserName = person.PersonName,
                //        Right = UserRightType.NotAllow
                //    });

                //}

                //return createProjectViewModel;
            }
        }
    }
}