using JurDocsWinForms.Model;

namespace JurDocsWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            ApplicationConfiguration.Initialize();

            var loginForm = new LoginForm();
            ProgramHelpers.MoveWindowToCenterScreen(loginForm);
            loginForm.ShowDialog();

            if (Auth.Token == Guid.Empty)
            {
                MessageBox.Show("Неверное имя пользователя или пароль");
                return;
            }

            var mainForm = new MainForm();
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
