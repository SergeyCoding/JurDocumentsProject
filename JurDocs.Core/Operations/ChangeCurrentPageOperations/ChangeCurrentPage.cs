using JurDocs.Common.Operations;
using JurDocs.Core.Constants;

namespace JurDocs.Core.Operations.ChangeCurrentPageOperations
{
    /// <summary>
    /// 
    /// </summary>
    public class ChangeCurrentPage() : IOperation<ChangeCurrentPageContext>
    {
        public Task ExecuteAsync(ChangeCurrentPageContext context)
        {
            if (context.TextPage == null)
                context.State.CurrentPage = AppPage.Null;

            if (context.TextPage == "Проект")
                context.State.CurrentPage = AppPage.Проект;

            if (context.TextPage == "Справка")
                context.State.CurrentPage = AppPage.Справка;

            if (context.TextPage == "Письмо")
                context.State.CurrentPage = AppPage.Письмо;

            if (context.TextPage == "Выписка")
                context.State.CurrentPage = AppPage.Выписка;

            if (context.TextPage == "Договор")
                context.State.CurrentPage = AppPage.Договор;

            return Task.CompletedTask;
        }
    }
}
