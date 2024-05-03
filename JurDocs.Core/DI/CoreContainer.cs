using Autofac;
using JurDocs.Core.Commands;
using JurDocs.Core.Commands.Impl;
using JurDocs.Core.States;

namespace JurDocs.Core.DI
{
    /// <summary>
    /// 
    /// </summary>
    public static class CoreContainer
    {
        private static IContainer? _container;

        private static readonly object _lock = new();

        public static IContainer Get()
        {
            if (_container != null)
                return _container;

            lock (_lock)
            {
                if (_container != null)
                    return _container;

                var builder = new ContainerBuilder();

                builder.RegisterType<AppState>().SingleInstance();
                builder.RegisterType<GetState>().As<IGetState>();

                builder.RegisterType<CreateProjectOrDocument>().As<ICreateProjectOrDocument>();
                builder.RegisterType<CreateProject>().As<ICreateProject>();

                builder.RegisterType<ChangeCurrentPage>().As<IChangeCurrentPage>();

                builder.RegisterType<ChangeCurrentProject>().As<IChangeCurrentProject>();

                builder.RegisterType<InitApiClient>().As<IInitApiClient>();

                builder.RegisterType<SaveProject>().As<ISaveProject>();

                builder.RegisterType<DeleteProject>().As<IDeleteProject>();

                _container = builder.Build();

                return _container;
            }
        }

        public static T Get<T>() where T : class
        {
            return Get().Resolve<T>();
        }

        public static IGetState GetState()
        {
            return Get().Resolve<IGetState>();
        }
    }
}
