using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.States;
using JurDocs.Core.Views;
using System.Linq;

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
                    Right = GetRight(answerRightsResult, JurDocType.All, person)
                });

                projDto.ProjectRights_Справки.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = GetRight(answerRightsResult, JurDocType.Справка, person)
                });

                projDto.ProjectRights_Выписки.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = GetRight(answerRightsResult, JurDocType.Выписка, person)
                });
            }

            mainView.OpenProjectEditor(projDto);
        }

        private static UserRightType GetRight(ICollection<Client.ProjectRights> answerRightsResult,
                                              JurDocType docType,
                                              Client.PersonGetResponse person)
        {
            var elems = answerRightsResult
                .Where(x => x.DocType == docType.ToString())
                .Where(item => item.UserId == person.PersonId);

            return elems.Any() ? UserRightType.Allow : UserRightType.NotAllow;
        }
    }
}
