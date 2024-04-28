using JurDocs.Client;
using JurDocs.Common.EnumTypes;
using JurDocs.Core.Commands;
using JurDocs.Core.Model;

namespace JurDocs.WinForms.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateProjectViewModel(JurDocsClient client)
    {
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectFullName { get; set; } = string.Empty;
        public int ProjectOwnerId { get; set; }
        public List<UserRight> ProjectRights { get; } = [];
        public List<UserRight> ProjectRights_Справки { get; } = [];
        public List<UserRight> ProjectRights_Выписки { get; } = [];
        public int ProjectId { get; internal set; }
        public string ProjectOwnerName { get; internal set; } = string.Empty;

        internal async Task DeleteProjectAsync()
        {
            await client.ProjectDELETEAsync(ProjectId);
        }

        /// <summary>
        /// 
        /// </summary>
        internal async Task InitNewProject()
        {
            var swaggerResponse = await client.ProjectPOSTAsync();

            var persons = (await client.PersonAsync()).Result;

            var result = swaggerResponse.Result;

            var ownerId = result.OwnerId;

            ProjectId = result.Id;
            ProjectName = result.Name;
            ProjectFullName = result.FullName;
            ProjectOwnerId = result.OwnerId;
            ProjectOwnerName = persons.FirstOrDefault(x => x.PersonId == ownerId)!.PersonName;

            foreach (var person in persons)
            {
                ProjectRights.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });

                ProjectRights_Справки.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });

                ProjectRights_Выписки.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });

            }
        }


        internal async Task SaveProjectAsync()
        {

            var project = new JurDocProject
            {
                Id = ProjectId,
                FullName = ProjectFullName,
                IsDeleted = false,
                Name = ProjectName,
                OwnerId = ProjectOwnerId
            };

            var rights = new List<UserRight>();

            foreach (var item in ProjectRights)
            {
                item.DocType = JurDocType.All;
                rights.Add(item);
            }

            foreach (var item in ProjectRights_Справки)
            {
                item.DocType = JurDocType.Справка;
                rights.Add(item);
            }

            foreach (var item in ProjectRights_Выписки)
            {
                item.DocType = JurDocType.Выписка;
                rights.Add(item);
            }

            await new SaveProject(project).ExecuteAsync();
            await new SaveRights(project, rights).ExecuteAsync();
        }
    }
}
