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

                while (letter.Sender.Count < 10)
                    letter.Sender.Add(string.Empty);

                while (letter.Recipient.Count < 10)
                    letter.Recipient.Add(string.Empty);

                var answerProject = await state.Client.ProjectGETAsync(letter.ProjectId);
                var projectName = answerProject.Result.Data.First().Name;


                var editedDocData = new EditedDocData
                {
                    Id = letter.Id,
                    DateIncoming = letter.DateIncoming,
                    DateOutgoing = letter.DateOutgoing,
                    DocType = letter.DocType,
                    ExecutivePerson = letter.ExecutivePerson,
                    IsDeleted = letter.IsDeleted,
                    DocName = letter.Name,
                    NumberIncoming = letter.NumberIncoming,
                    NumberOutgoing = letter.NumberOutgoing,
                    ProjectId = letter.ProjectId,
                    ProjectName = projectName,
                    Sender = [.. letter.Sender],
                    Recipient = [.. letter.Recipient],
                };

                try
                {
                    var fn = (await state.Client.LocalFilenameAsync(
                        projectName,
                        JurDocType.Письмо.GetDescription(),
                        letter.Id)).Result.Data.First();

                    if (File.Exists(fn))
                        File.Delete(fn);

                    var res = (await state.Client.DocumentFileGETAsync(projectName, letter.DocType.GetDescription(), fn)).Result;

                    editedDocData.FileName = res ? fn : string.Empty;
                }
                catch (Exception)
                {
                    editedDocData.FileName = string.Empty;
                }

                mainView.OpenDocEditor(editedDocData);

                return;
            }

            throw new Exception("Нет реализации для данного вида документа");
        }
    }
}