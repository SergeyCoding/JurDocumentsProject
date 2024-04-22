using JurDocs.Core.Constants;
using JurDocs.Core.States;

namespace JurDocs.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class ChangeCurrentPage(string textPage)
    {
        private readonly string _textPage = textPage;

        public void Execute()
        {
            if (_textPage == null)
                AppState.Instance.CurrentPage = AppPage.Null;

            if (_textPage == "Проект")
                AppState.Instance.CurrentPage = AppPage.Проект;

            if (_textPage == "Справка")
                AppState.Instance.CurrentPage = AppPage.Справка;

            if (_textPage == "Письмо")
                AppState.Instance.CurrentPage = AppPage.Письмо;

            if (_textPage == "Выписка")
                AppState.Instance.CurrentPage = AppPage.Выписка;

            if (_textPage == "Договор")
                AppState.Instance.CurrentPage = AppPage.Договор;
        }
    }
}
