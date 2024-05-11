using Autofac;
using JurDocs.Client;
using JurDocs.Core.Commands;
using JurDocs.Core.DI;
using JurDocs.WinForms.Configuration;
using JurDocs.WinForms.DI;
using JurDocsWinForms;
using JurDocsWinForms.Model;
using Microsoft.Extensions.Configuration;

namespace JurDocs.WinForms
{
    internal static class Program
    {
        private const string _appsettingFile = "appsettings.json";


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var configStart = new ConfigurationBuilder().AddJsonFile(_appsettingFile).Build();

                var jdSettings = configStart.GetSection(JurDocsApp.sectionName).Get<JurDocsApp>();

                if (jdSettings == null)
                    throw new Exception("Ошибка в конфигурационном файле.");

                if (!string.IsNullOrWhiteSpace(jdSettings?.AdditionalConfig))
                {
                    configStart = new ConfigurationBuilder()
                        .AddJsonFile(_appsettingFile)
                        .AddJsonFile($"appsettings.{jdSettings.AdditionalConfig}.json")
                        .Build();

                    jdSettings = configStart.GetSection(JurDocsApp.sectionName).Get<JurDocsApp>();
                }

                jdSettings!.Validate();



                JurClientService.UrlBase = jdSettings.UrlBase!;
            }
            catch (Exception e)
            {
                _ = MessageBox.Show(e.Message);
                return;
            }


            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            var container = Views.Container();

            ApplicationConfiguration.Initialize();

            Task.Delay(1500).GetAwaiter().GetResult();

            if (!LoginAction(container))
            {
                MessageBox.Show("Неверное имя пользователя или пароль");
                return;
            }


            var token = container.Resolve<WorkSession>().User.Token;
            CoreContainer.Get<IInitApiClient>().Execute(token);

            using (var lifetimeScope = container.BeginLifetimeScope())
            {
                //var mainForm = new MainForm { WorkSession = workSession };
                var mainForm = lifetimeScope.Resolve<MainForm>();
                ProgramHelpers.MoveWindowToCenterScreen(mainForm);
                Application.Run(mainForm);
            }
        }



        private static bool LoginAction(IContainer container)
        {
            var workSession = container.Resolve<WorkSession>();

            if (AppConst.IsLogin)
            {
                var loginForm = container.Resolve<LoginForm>();
                ProgramHelpers.MoveWindowToCenterScreen(loginForm);
                loginForm.ShowDialog();
            }
            else
            {
                // блок для тестирования, чтобы не вводить логин, пароль

                for (var i = 0; i < 10; i++)
                {
                    try
                    {
                        const string curLogin = "user2";
                        const string curPwd = "";

                        var client = JurClientService.JurDocsClientFactory();
                        var token = client.LoginPOSTAsync(new LoginPostRequest { Login = curLogin, Password = curPwd })
                            .GetAwaiter()
                            .GetResult();

                        workSession.User.Login = curLogin;
                        workSession.User.Token = token.Result;

                        break;
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            var client2 = container.Resolve<JurDocsClient>();
            var user = client2.LoginGETAsync(workSession.User.Login).GetAwaiter().GetResult();

            workSession.User.UserName = user.Result.Name;
            workSession.User.TempDir = user.Result.Path;

            return workSession.User.Token != Guid.Empty;
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // All exceptions thrown by the main thread are handled over this method
            ShowExceptionDetails(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // All exceptions thrown by additional threads are handled in this method
            if (e.ExceptionObject is Exception ex)
                ShowExceptionDetails(ex);

            // Suspend the current thread for now to stop the exception from throwing.
#pragma warning disable CS0618 // Type or member is obsolete
            Thread.CurrentThread.Suspend();
        }

        static void ShowExceptionDetails(Exception Ex)
        {
            MessageBox.Show(Ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
