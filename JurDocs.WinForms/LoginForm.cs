using JurDocs.Client;
using JurDocsWinForms.Model;

namespace JurDocsWinForms;

public partial class LoginForm : Form
{
    private readonly WorkSession _workSession;

    public LoginForm(WorkSession workSession)
    {
        InitializeComponent();
        _workSession = workSession;
    }

    private async void BtnExitClick(object sender, EventArgs e)
    {
        try
        {
            var client = JurClientService.JurDocsClientFactory();
            var token = await client.LoginPOSTAsync(new LoginPostRequest
            {
                Login = tbLogin.Text,
                Password = tbPwd.Text
            });

            if (token.Result != Guid.Empty)
            {
                _workSession.User.Login = tbLogin.Text;
                _workSession.User.Token = token.Result;

                Close();

                return;
            }
        }
        catch (Exception)
        {

        }

        MessageBox.Show(this, "Неверное имя пользователя или пароль");

    }
}
