using JurDocs.Core.Constants;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands.Impl
{
    /// <summary>
    /// 
    /// </summary>
    internal class ChangeCurrentPage(AppState state) : IChangeCurrentPage
    {
        public Task ExecuteAsync(string textPage)
        {

            if (string.IsNullOrEmpty(textPage))
            {
                state.CurrentPage = AppPage.Null;
                return Task.CompletedTask;
            }

            if (textPage == "Проект")
                state.CurrentPage = AppPage.Проект;

            if (textPage == "Справка")
                state.CurrentPage = AppPage.Справка;

            if (textPage == "Письмо")
                state.CurrentPage = AppPage.Письмо;

            if (textPage == "Выписка")
                state.CurrentPage = AppPage.Выписка;

            if (textPage == "Договор")
                state.CurrentPage = AppPage.Договор;

            return Task.CompletedTask;
        }
    }
}
