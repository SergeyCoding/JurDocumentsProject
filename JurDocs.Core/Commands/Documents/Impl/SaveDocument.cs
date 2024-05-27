using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands.Documents.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class SaveDocument(AppState state) : ISaveDocument
    {

        public async Task ExecuteAsync(EditedDocData data)
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

                if (!string.IsNullOrEmpty(data.FileName) && File.Exists(data.FileName))
                {

                    var fn = (await state.Client.LocalFilenameAsync(
                        state.CurrentProject.Name,
                        JurDocType.Письмо.GetDescription(),
                        state.CurrentDocumentId)).Result.Data.First();

                    var dir = Path.GetDirectoryName(fn);

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir!);

                    if (data.FileName != fn)
                        File.Copy(data.FileName, fn, true);

                    await state.Client.DocumentFilePOSTAsync(state.CurrentProject.Name,
                                                            JurDocType.Письмо.GetDescription(),
                                                            fn);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}