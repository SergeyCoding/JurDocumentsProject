using JurDocs.Client;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class CreateDocument(AppState state) : ICreateDocument
    {
        /// <summary>
        /// 
        /// </summary>

        public async Task ExecuteAsync(IMainView mainView)
        {

            try
            {
                var answer = await state.Client.LetterDocumentPOSTAsync(state.CurrentProject.Id);

                if (answer.Result.Status != "OK")
                    throw new Exception(answer.Result.MessageToUser);

                var result = answer.Result.Data.First();

                var letterDocument = new LetterDocument
                {
                    Id = result.Id,
                    DateIncoming = result.DateIncoming,
                    DateOutgoing = result.DateOutgoing,
                    DocType = result.DocType,
                    ExecutivePerson = result.ExecutivePerson,
                    IsDeleted = result.IsDeleted,
                    Name = result.Name,
                    NumberIncoming = result.NumberIncoming,
                    NumberOutgoing = result.NumberOutgoing,
                    ProjectId = result.ProjectId,
                    Sender = [.. result.Sender],
                    Recipient = [.. result.Recipient],
                };

                mainView.OpenDocEditor(letterDocument);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
