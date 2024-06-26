﻿using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Projects.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class CreateProject(AppState state) : ICreateProject
    {
        /// <summary>
        /// 
        /// </summary>
        public async Task ExecuteAsync(IMainView mainView)
        {
            var persons = (await state.Client.PersonAsync()).Result;

            var newProject = (await state.Client.ProjectPOSTAsync()).Result;

            state.CurrentProject = newProject;

            var ownerId = newProject.OwnerId;

            var projDto = new EditedProjectData
            {
                OpenType = OpenEditorType.Create,
                ProjectId = newProject.Id,
                ProjectName = newProject.Name,
                ProjectFullName = newProject.FullName,
                ProjectOwnerId = newProject.OwnerId,
                ProjectOwnerName = persons.FirstOrDefault(x => x.PersonId == ownerId)!.PersonName,
            };

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

                projDto.ProjectRights_Письма.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });
            }

            mainView.OpenProjectEditor(projDto);
        }
    }
}
