using JurDocs.Client;
using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands
{
    public class SaveRights(JurDocProject project, List<UserRight> rights)
    {
        public async Task ExecuteAsync()
        {
            try
            {
                var _client = AppState.Instance.Client;
                var answer = await _client.ProjectGETAsync(project.Id);

                if (answer.Result.Status != "OK") {
                    throw new Exception(answer.Result.MessageToUser);
                }

                var newProject = answer.Result.Data;

                var resp = await _client.RightsAllAsync(newProject.First().Id).ConfigureAwait(false);
                var newRights = resp.Result;

                foreach (var item in rights)
                {
                    if (item.Right == UserRightType.Allow)
                    {
                        await _client.RightsPOSTAsync(new RightsPostRequest
                        {
                            UserId = item.UserId,
                            DocType = item.DocType.ToString(),
                            ProjectId = newProject.First().Id,
                        }).ConfigureAwait(false);
                    }
                    else
                    {
                        //var value = newRights.FirstOrDefault(x => x.DocType == item.DocType.ToString());
                        //if (value != null)
                        //{
                        //    await _client.RightsDELETEAsync(newProject.Id, item.DocType.ToString(), item.UserId);
                        //}
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
