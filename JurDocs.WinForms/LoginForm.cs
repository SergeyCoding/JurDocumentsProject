using JurDocs.Client;
using JurDocsWinForms.Model;

namespace JurDocsWinForms;

public partial class LoginForm : Form
{
    private WorkSession? _workSession = null;

    public LoginForm()
    {
        InitializeComponent();
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
                _workSession = new WorkSession(new CurrentUser { Token = token.Result });
        }
        catch (Exception)
        {

        }

        Close();
    }

    internal WorkSession? GetWorkSession()
    {
        return _workSession;
    }


}
