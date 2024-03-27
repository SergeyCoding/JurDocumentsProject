using JurDocsWinForms.Model;
using LexExchangeApi.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JurDocsWinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = JurDocsClient.JurClientService.JurDocsClientFactory();
                var token = await client.LoginPOSTAsync(new LoginPostRequest
                {
                    Login = tbLogin.Text,
                    Password = tbLogin.Text
                });

                Auth.Token = token.Result;
            }
            catch (Exception)
            {
                Auth.Token = Guid.Empty;
            }

            Close();
        }
    }
}
