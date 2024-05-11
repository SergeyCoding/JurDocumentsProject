using JurDocs.Core.Commands.Documents;
using JurDocs.Core.States;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Impl
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

                mainView.OpenDocEditor(letter);

                return;
            }

            throw new Exception("Нет реализации для данного вида документа");
        }
    }
}