using Autofac;
using JurDocs.Core.Commands;
using JurDocs.Core.States;

namespace JurDocs.WinForms.DI
{
    /// <summary>
    /// 
    /// </summary>
    public static class JurDocsCoreContainer
    {
        private static IContainer? _container;

        public static IContainer GetContainer()
        {
            if (_container == null)
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<AppState>();

                builder.RegisterType<CreateNewDoc>().As<ICreateNewDoc>();
                builder.RegisterType<CreateProject>().As<ICreateProject>();

                _container = builder.Build();
            }

            return _container;
        }
    }
}
