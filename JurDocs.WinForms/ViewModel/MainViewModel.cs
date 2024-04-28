using JurDocs.Client;
using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.WinForms.Model;

namespace JurDocs.WinForms.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MainViewModel(JurDocsClient client)
    {
        internal async Task<ProjectListTable[]> GetProjectList()
        {
            var swaggerResponse = await client.ProjectAllAsync();
            List<JurDocProject> projectList = [.. swaggerResponse.Result.Where(x => !string.IsNullOrWhiteSpace(x.Name))];

            var data = new List<ProjectListTable>();

            var u = await GetUserList();

            foreach (var item in projectList)
                data.Add(new ProjectListTable { Id = item.Id, ProjectName = item.Name, ProjectFullName = item.FullName, Owner = u.FirstOrDefault(x => x.PersonId == item.OwnerId)?.PersonName });

            return [.. data!];
        }

        /// <summary>
        /// 
        /// </summary>
        internal async Task<CreateProjectViewModel> CreateNewProject()
        {
            var swaggerResponse = await client.ProjectPOSTAsync();

            var persons = (await client.PersonAsync()).Result;

            var result = swaggerResponse.Result;

            var ownerId = result.OwnerId;

            var createProjectViewModel = new CreateProjectViewModel(client)
            {
                ProjectId = result.Id,
                ProjectName = result.Name,
                ProjectFullName = result.FullName,
                ProjectOwnerId = result.OwnerId,
                ProjectOwnerName = persons.FirstOrDefault(x => x.PersonId == ownerId)!.PersonName,
            };

            foreach (var person in persons)
            {
                createProjectViewModel.ProjectRights.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });

                createProjectViewModel.ProjectRights_Справки.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });

                createProjectViewModel.ProjectRights_Выписки.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });

            }

            return createProjectViewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal async Task<AddNewDocViewModel> CreateNewDoc()
        {
            await Task.Delay(10);

            //var swaggerResponse = await client.ProjectPOSTAsync();

            //var persons = (await client.PersonAsync()).Result;

            //var result = swaggerResponse.Result;

            //var ownerId = result.OwnerId;

            var createProjectViewModel = new AddNewDocViewModel(client)
            {
                //ProjectId = result.Id,
                //ProjectName = result.Name,
                //ProjectFullName = result.FullName,
                //ProjectOwnerId = result.OwnerId,
                //ProjectOwnerName = persons.FirstOrDefault(x => x.PersonId == ownerId)!.PersonName,
            };


            return createProjectViewModel;
        }



        internal async Task<PersonGetResponse[]> GetUserList()
        {
            var users = await client.PersonAsync();
            return [.. users.Result!];
        }

        internal async Task<string[]> GetProjectNameList()
        {
            var swaggerResponse = await client.ProjectAllAsync();
            return [.. swaggerResponse.Result.Select(x => x.Name).Where(x => !string.IsNullOrWhiteSpace(x))];
        }

        internal void CreateNewLetter()
        {

        }
    }
}
