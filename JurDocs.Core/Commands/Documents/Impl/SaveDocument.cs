﻿using JurDocs.Core.Model;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands.Documents.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class SaveDocument(AppState state) : ISaveDocument
    {

        public async Task ExecuteAsync( EditedDocData data)
        {
            if (state.CurrentPage == Constants.AppPage.Письмо)
            {
                await Save_Письмо(data);
            }
        }

        private async Task Save_Письмо(EditedDocData data)
        {
            try
            {

                var letter = new Client.LetterDocument
                {
                    Id = data.Id,
                    DateIncoming = data.DateIncoming,
                    DateOutgoing = data.DateOutgoing,
                    DocType = data.DocType,
                    ExecutivePerson = data.ExecutivePerson,
                    IsDeleted = data.IsDeleted,
                    Name = data.DocName,
                    NumberIncoming = data.NumberIncoming,
                    NumberOutgoing = data.NumberOutgoing,
                    ProjectId = data.ProjectId,
                    Recipient = data.Recipient,
                    Sender = data.Sender
                };

                var answer = await state.Client.LetterDocumentPUTAsync(letter);

                //var answer = await state.Client.LetterDocumentPOSTAsync(state.CurrentProject.Id);

                //if (answer.Result.Status != "OK")
                //    throw new Exception(answer.Result.MessageToUser);

                //var result = answer.Result.Data.First();

                //var answerProject = await state.Client.ProjectGETAsync(result.ProjectId);
                //var jurDocProject = answerProject.Result.Data.First();

                //var editedDocData = new EditedDocData
                //{
                //    Id = result.Id,
                //    DateIncoming = result.DateIncoming,
                //    DateOutgoing = result.DateOutgoing,
                //    DocType = (JurDocType)(int)result.DocType,
                //    ExecutivePerson = result.ExecutivePerson,
                //    IsDeleted = result.IsDeleted,
                //    DocName = result.Name,
                //    NumberIncoming = result.NumberIncoming,
                //    NumberOutgoing = result.NumberOutgoing,
                //    ProjectId = result.ProjectId,
                //    Sender = [.. result.Sender],
                //    Recipient = [.. result.Recipient],
                //    ProjectName = jurDocProject.Name,
                //    OpenType = OpenEditorType.Create,
                //    CloseType = CloseEditorType.None,
                //    FileName = fileName
                //};

                //for (var i = editedDocData.Sender.Count; i < 10; i++)
                //    editedDocData.Sender.Add(string.Empty);

                //for (var i = editedDocData.Recipient.Count; i < 10; i++)
                //    editedDocData.Recipient.Add(string.Empty);


                //mainView.OpenDocEditor(editedDocData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
