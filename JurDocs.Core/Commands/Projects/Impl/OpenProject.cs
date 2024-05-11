using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Projects.Impl
{
    /// <summary>
    /// Открыть проект
    /// </summary>
    internal class OpenProject(AppState state) : IOpenProject
    {
        public async Task ExecuteAsync(IMainView mainView)
        {
            var persons = (await state.Client.PersonAsync()).Result;

            var answer = await state.Client.ProjectGETAsync(state.CurrentProject.Id);
            var project = answer.Result.Data.First();

            var projDto = new EditedProjectData
            {
                OpenType = OpenEditorType.Edit,
                ProjectId = project.Id,
                ProjectName = project.Name,
                ProjectFullName = project.FullName,
                ProjectOwnerId = project.OwnerId,
                ProjectOwnerName = persons.FirstOrDefault(x => x.PersonId == project.OwnerId)!.PersonName,
            };

            var answerRights = await state.Client.RightsAllAsync(project.Id);
            var answerRightsResult = answerRights.Result;

            foreach (var person in persons)
            {
                projDto.ProjectRights.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });

                projDto.ProjectRights_Справки.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });

                projDto.ProjectRights_Выписки.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });
            }

            mainView.OpenProjectEditor(projDto);


            //---


            //if (state.CurrentPage == Constants.AppPage.Проект)
            //{


            //    var projectData = new EditedProjectData
            //    {
            //        OpenType = OpenEditorType.Edit,
            //        ProjectId = project.Id,
            //        ProjectFullName = project.FullName,
            //        ProjectName = project.Name,
            //        ProjectOwnerId = project.OwnerId,
            //        ProjectOwnerName = "",
            //    };

            //    var answerPersons = await state.Client.PersonAsync();
            //    var personList = answerPersons.Result.ToDictionary(x => x.PersonId, x => x);


            //    var answerRights = await state.Client.RightsAllAsync(project.Id);
            //    var result = answerRights.Result;

            //    foreach (var item in result)
            //    {
            //        SetRight(projectData, item, JurDocType.Письмо, personList);
            //        SetRight(projectData, item, JurDocType.Выписка, personList);
            //    }


            //    mainView.OpenProjectEditor(projectData);

            //    return;
            //}

            //throw new Exception("Нет реализации для данного вида документа");
        }


        private static void SetRight(EditedProjectData projectData, Client.ProjectRights rights, JurDocType docType, Dictionary<int, Client.PersonGetResponse> personList)
        {
            if (rights.DocType == docType.ToString() || rights.DocType == JurDocType.All.ToString())
            {
                var userRight = new UserRight
                {
                    DocType = JurDocType.Письмо,
                    Right = UserRightType.Allow,
                    UserId = rights.Id,
                    UserName = personList[rights.Id].PersonName,
                };

                projectData.ProjectRights.Add(userRight);
            }
        }

    }
}
