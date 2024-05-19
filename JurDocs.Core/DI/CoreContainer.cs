using Autofac;
using JurDocs.Core.Commands;
using JurDocs.Core.Commands.Documents;
using JurDocs.Core.Commands.Documents.Impl;
using JurDocs.Core.Commands.Impl;
using JurDocs.Core.Commands.Projects;
using JurDocs.Core.Commands.Projects.Impl;
using JurDocs.Core.Commands.Rights;
using JurDocs.Core.Commands.Rights.Impl;
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

                builder.RegisterType<InitApiClient>().As<IInitApiClient>();

                builder.RegisterType<CreateProjectOrDocument>().As<ICreateProjectOrDocument>();
                builder.RegisterType<OpenProjectOrDocument>().As<IOpenProjectOrDocument>();

                builder.RegisterType<ChangeCurrentPage>().As<IChangeCurrentPage>();
                builder.RegisterType<ChangeCurrentProject>().As<IChangeCurrentProject>();

                builder.RegisterType<CreateProject>().As<ICreateProject>();
                builder.RegisterType<SaveProject>().As<ISaveProject>();
                builder.RegisterType<OpenProject>().As<IOpenProject>();
                builder.RegisterType<CloseProject>().As<ICloseProject>();
                builder.RegisterType<DeleteProject>().As<IDeleteProject>();

                builder.RegisterType<SaveRights>().As<ISaveRights>();

                builder.RegisterType<CreateDocument>().As<ICreateDocument>();
                builder.RegisterType<GetDocumentList>().As<IGetDocumentList>();
                builder.RegisterType<OpenDocument>().As<IOpenDocument>();
                builder.RegisterType<SaveDocument>().As<ISaveDocument>();
                builder.RegisterType<CloseDocument>().As<ICloseDocument>();

                builder.RegisterType<ChangeCurrentDocument>().As<IChangeCurrentDocument>();

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
