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


    }
}
