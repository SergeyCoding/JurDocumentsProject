using Autofac;

namespace JurDocs.Core.Di
{
    /// <summary>
    /// 
    /// </summary>
    public static class Views

    {
        private static IContainer? _container;

        private static readonly object _lock = new();

        public static IContainer Container()
        {
            if (_container != null)
                return _container;

            lock (_lock)
            {
                if (_container != null)
                    return _container;
                var builder = new ContainerBuilder();

                //builder.RegisterType<IProjectV>().SingleInstance();

                //builder.RegisterType<CreateNewDoc>().As<ICreateDocument>();
                //builder.RegisterType<CreateProject>().As<ICreateProject>();

                _container = builder.Build();

                return _container;
            }
        }
    }
}
