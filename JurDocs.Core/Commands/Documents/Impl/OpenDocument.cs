using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Documents.Impl
{
    /// <summary>
    /// 
    /// </summary>
    class OpenDocument(AppState state) : IOpenDocument
    {
        public async Task ExecuteAsync(IMainView mainView)
        {
            if (state.CurrentPage == Constants.AppPage.Письмо)
            {
                var answer = await state.Client.LetterDocumentGET2Async(state.CurrentProject.Id);

                var letter = answer.Result.Data.First().First(x => x.Id == state.CurrentDocumentId);

                var docType = (JurDocType)letter.DocType;

                var editedDocData = new EditedDocData
                {
                    Id = letter.Id,
                    DateIncoming = letter.DateIncoming,
                    DateOutgoing = letter.DateOutgoing,
                    DocType = docType,
                    ExecutivePerson = letter.ExecutivePerson,
                    IsDeleted = letter.IsDeleted,
                    DocName = letter.Name,
                    NumberIncoming = letter.NumberIncoming,
                    NumberOutgoing = letter.NumberOutgoing,
                    ProjectId = letter.ProjectId,
                    Sender = [.. letter.Sender],
                    Recipient = [.. letter.Recipient],
                };

                mainView.OpenDocEditor(editedDocData);

                return;
            }

            throw new Exception("Нет реализации для данного вида документа");
        }
    }
}