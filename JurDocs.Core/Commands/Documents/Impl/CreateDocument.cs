using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Documents.Impl
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
            await Create_Письмо(mainView, null);
        }

        public async Task ExecuteWithDragDropAsync(IMainView mainView, string fileName)
        {
            await Create_Письмо(mainView, fileName);
        }

        private async Task Create_Письмо(IMainView mainView, string? fileName)
        {
            try
            {
                if (state.CurrentPage == Constants.AppPage.Письмо)
                {
                    var answer = await state.Client.LetterDocumentPOSTAsync(state.CurrentProject.Id);

                    if (answer.Result.Status != "OK")
                        throw new Exception(answer.Result.MessageToUser);

                    var result = answer.Result.Data.First();

                    var answerProject = await state.Client.ProjectGETAsync(result.ProjectId);
                    var jurDocProject = answerProject.Result.Data.First();

                    var editedDocData = new EditedDocData
                    {
                        Id = result.Id,
                        DateIncoming = result.DateIncoming,
                        DateOutgoing = result.DateOutgoing,
                        DocType = (JurDocType)(int)result.DocType,
                        ExecutivePerson = result.ExecutivePerson,
                        IsDeleted = result.IsDeleted,
                        DocName = result.Name,
                        NumberIncoming = result.NumberIncoming,
                        NumberOutgoing = result.NumberOutgoing,
                        ProjectId = result.ProjectId,
                        Sender = [.. result.Sender],
                        Recipient = [.. result.Recipient],
                        ProjectName = jurDocProject.Name,
                        OpenType = OpenEditorType.Create,
                        CloseType = CloseEditorType.None,
                        FileName = fileName
                    };

                    for (var i = editedDocData.Sender.Count; i < 10; i++)
                        editedDocData.Sender.Add(string.Empty);

                    for (var i = editedDocData.Recipient.Count; i < 10; i++)
                        editedDocData.Recipient.Add(string.Empty);


                    mainView.OpenDocEditor(editedDocData);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
