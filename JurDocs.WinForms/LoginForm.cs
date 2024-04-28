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
                Password = tbLogin.Text
            });

            if (token.Result != Guid.Empty)
            {
                _workSession.User.Login = tbLogin.Text;
                _workSession.User.Token = token.Result;
            }
        }
        catch (Exception)
        {

        }

        Close();
    }
}
