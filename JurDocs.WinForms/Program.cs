using JurDocs.Client;
using JurDocs.WinForms.Configuration;
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

                jdSettings.Validate();

                JurClientService.UrlBase = jdSettings.UrlBase!;
            }
            catch (Exception e)
            {
                _ = MessageBox.Show(e.Message);
                return;
            }


            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            ApplicationConfiguration.Initialize();

            WorkSession? workSession = null;

            Task.Delay(1500).GetAwaiter().GetResult();

            if (AppConst.IsLogin)
            {
                var loginForm = new LoginForm();
                ProgramHelpers.MoveWindowToCenterScreen(loginForm);
                loginForm.ShowDialog();

                workSession = loginForm.GetWorkSession();

                if (workSession == null)
                {
                    MessageBox.Show("Неверное имя пользователя или пароль");
                    return;
                }
            }
            else
            {
                // блок для тестирования, чтобы не вводить логин, пароль

                const string curLogin = "user2";
                const string curPwd = "";

                var client = JurClientService.JurDocsClientFactory();
                var token = client.LoginPOSTAsync(new LoginPostRequest { Login = curLogin, Password = curPwd })
                    .GetAwaiter()
                    .GetResult();

                var client2 = JurClientService.JurDocsClientFactory(token.Result);

                var user = client2.LoginGETAsync(curLogin).GetAwaiter().GetResult();

                workSession = new WorkSession(new CurrentUser { Token = token.Result, UserName = user.Result.Name, TempDir = user.Result.Path });
            }

            if (workSession == null)
                return;

            var mainForm = new MainForm { WorkSession = workSession };
            ProgramHelpers.MoveWindowToCenterScreen(mainForm);
            Application.Run(mainForm);
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
