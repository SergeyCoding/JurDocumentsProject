using JurDocs.Client;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands
{
    public class SaveProject(JurDocProject project)
    {
        public async Task ExecuteAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(project.Name))
                    throw new Exception("Проект должен иметь наименование");

                var _client = AppState.Instance.Client;

                var result = (await _client.ProjectPUTAsync(project)).Result;

                if (result != null && result.Status == "OK")
                {
                    AppState.Instance.CurrentProject = result.Data.First();
                }

                //var resp = await _client.RightsAllAsync(newProject.Id).ConfigureAwait(false);
                //var newRights = resp.Result;

                //foreach (var item in rights)
                //{
                //    if (item.Right == UserRightType.Allow)
                //    {
                //        await _client.RightsPOSTAsync(new RightsPostRequest
                //        {
                //            UserId = item.UserId,
                //            DocType = item.DocType.ToString(),
                //            ProjectId = newProject.Id,
                //        }).ConfigureAwait(false);
                //    }
                //    else
                //    {
                //        //var value = newRights.FirstOrDefault(x => x.DocType == item.DocType.ToString());
                //        //if (value != null)
                //        //{
                //        //    await _client.RightsDELETEAsync(newProject.Id, item.DocType.ToString(), item.UserId);
                //        //}
                //    }
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
