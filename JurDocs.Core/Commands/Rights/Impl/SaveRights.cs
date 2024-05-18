using JurDocs.Client;
using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands.Rights.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class SaveRights(AppState state) : ISaveRights
    {
        public async Task ExecuteAsync(int projectId, List<UserRight> rights)
        {
            try
            {
                var _client = state.Client;
                var answer = await _client.ProjectGETAsync(projectId);

                if (answer.Result.Status != "OK")
                    throw new Exception(answer.Result.MessageToUser);

                var resp = await _client.RightsAllAsync(projectId);
                var currentRights = resp.Result;

                foreach (var item in rights)
                {
                    if (item.Right == UserRightType.Allow)
                    {
                        await _client.RightsPOSTAsync(new RightsPostRequest
                        {
                            UserId = item.UserId,
                            DocType = item.DocType.ToString(),
                            ProjectId = projectId,
                        });
                    }
                    else
                    {
                        var value = currentRights
                            .Where(x => x.UserId == item.UserId)
                            .FirstOrDefault(x => x.DocType == item.DocType.ToString());

                        if (value != null)
                            await _client.RightsDELETEAsync(value);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ExecuteAsync(EditedProjectData project)
        {
            List<UserRight> rights = [];

            rights.AddRange(project.ProjectRights);
            rights.AddRange(project.ProjectRights_Справки);
            rights.AddRange(project.ProjectRights_Выписки);
            rights.AddRange(project.ProjectRights_Письма);

            await ExecuteAsync(project.ProjectId, rights);
        }
    }
}
