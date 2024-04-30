﻿using Autofac;
using JurDocs.Client;
using JurDocs.Core.Commands;
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
        private static IContainer? _container;

        public static IContainer GetContainer()
        {
            if (_container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<CurrentUser>();
                builder.RegisterType<WorkSession>().SingleInstance();

                builder.Register(c => JurClientService.JurDocsClientFactory(c.Resolve<WorkSession>().User.Token));

                builder.RegisterType<MainForm>().PropertiesAutowired();
                builder.RegisterType<MainViewModel>();

                builder.RegisterType<CreateProjectForm>().PropertiesAutowired();
                builder.RegisterType<CreateProjectViewModel>();
                
                _container = builder.Build();
            }

            return _container;
        }
    }
}
