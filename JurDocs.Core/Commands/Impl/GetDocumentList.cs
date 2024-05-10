using JurDocs.Client;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// Получить список документов для текущего проекта
    /// </summary>
    internal class GetDocumentList(AppState state) : IGetDocumentList
    {
        public async Task<LetterDocument[]> ExecuteAsync()
        {
            try
            {
                var currentProject = state.CurrentProject;
                var answer = await state.Client.LetterDocumentGET2Async(currentProject.Id);

                if (answer.Result.Status == "OK")
                {
                    var letterDocuments = answer.Result.Data.First();
                    return [.. letterDocuments];
                }
                else
                {
                    throw new Exception(answer.Result.MessageToUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
