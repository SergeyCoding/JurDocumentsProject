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
    internal static class Views
    {
        private static IContainer? _container;

        private static readonly object _locker = new();

        public static IContainer Container()
        {
            if (_container != null)
                return _container;

            lock (_locker)
            {
                if (_container != null)
                    return _container;

                var builder = new ContainerBuilder();
                builder.RegisterType<CurrentUser>();
                builder.RegisterType<WorkSession>().SingleInstance();

                builder.Register(c => JurClientService.JurDocsClientFactory(c.Resolve<WorkSession>().User.Token));

                builder.RegisterType<MainForm>().PropertiesAutowired();
                builder.RegisterType<MainViewModel>();

                builder.RegisterType<CreateProjectForm>().PropertiesAutowired();
                builder.RegisterType<CreateProjectViewModel>();

                _container = builder.Build();

                return _container;
            }
        }
    }
}
