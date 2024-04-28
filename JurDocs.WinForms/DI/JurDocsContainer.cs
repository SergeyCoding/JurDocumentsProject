using Autofac;
using JurDocs.Client;
using JurDocs.WinForms.ViewModel;
using JurDocsWinForms;
using JurDocsWinForms.Model;

namespace JurDocs.WinForms.DI
{
    /// <summary>
    /// 
    /// </summary>
    internal static class JurDocsContainer
    {
        public static IContainer MakeContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CurrentUser>();
            builder.RegisterType<WorkSession>().SingleInstance();

            builder.Register(c => JurClientService.JurDocsClientFactory(c.Resolve<WorkSession>().User.Token));

            builder.RegisterType<MainForm>().PropertiesAutowired();
            builder.RegisterType<MainViewModel>();

            return builder.Build();
        }
    }
}
