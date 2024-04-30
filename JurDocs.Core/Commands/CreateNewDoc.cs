using JurDocs.Core.States;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    internal class CreateNewDoc(AppState state) : ICreateNewDoc
    {
        public void Execute()
        {
            state.CurrentProject = null;
        }

        /// <summary>
        /// 
        /// </summary>
        internal async Task Execute1()
        {
            await Task.CompletedTask;

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
