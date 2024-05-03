using JurDocs.Core.States;
using JurDocs.WinForms.ViewModel;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class CreateDocument(AppState state) : ICreateDocument
    {
        /// <summary>
        /// 
        /// </summary>
        public async Task<EditedDocData> ExecuteAsync()
        {
            await Task.CompletedTask;




            //var persons = (await state.Client.PersonAsync()).Result;

            var newProject = (await state.Client.ProjectPOSTAsync()).Result;

            //state.CurrentProject = newProject;

            //var ownerId = newProject.OwnerId;

            //var projDto = new EditedProjectData
            //{
            //    ProjectId = newProject.Id,
            //    ProjectName = newProject.Name,
            //    ProjectFullName = newProject.FullName,
            //    ProjectOwnerId = newProject.OwnerId,
            //    ProjectOwnerName = persons.FirstOrDefault(x => x.PersonId == ownerId)!.PersonName,
            //};

            //foreach (var person in persons)
            //{
            //    projDto.ProjectRights.Add(new UserRight
            //    {
            //        UserId = person.PersonId,
            //        UserName = person.PersonName,
            //        Right = UserRightType.NotAllow
            //    });

            //    projDto.ProjectRights_Справки.Add(new UserRight
            //    {
            //        UserId = person.PersonId,
            //        UserName = person.PersonName,
            //        Right = UserRightType.NotAllow
            //    });

            //    projDto.ProjectRights_Выписки.Add(new UserRight
            //    {
            //        UserId = person.PersonId,
            //        UserName = person.PersonName,
            //        Right = UserRightType.NotAllow
            //    });
            //}

            //mainView.OpenProjectEditor(projDto);

            return new EditedDocData();
        }
    }
}
