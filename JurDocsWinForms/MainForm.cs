using JurDocsClient;
using LexExchangeApi.Clients;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace JurDocsWinForms
{
    [SuppressMessage("Style", "IDE1006:Naming Styles")]

    public partial class MainForm : Form
    {
        private const string _noLoginStripStatus = "Выберите пользователя, и нажмите логин...";
        private bool _isLogin = false;
        private UserResponse? _currentUser = null;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = _noLoginStripStatus;
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var ftl = (List<FileTableList>)dataGridView1.DataSource;

                var fileTableList = ftl[e.RowIndex];

                //MessageBox.Show($"{_currentUser!.UserId} {fileTableList.DocType} {fileTableList.FileName}");

                var client = JurClientService.JurDocsClientFactory();

                var fileName = Path.Combine(_currentUser.Path, fileTableList.FileName!);

                var isError = false;
                try
                {
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                }
                catch (Exception)
                {
                    isError = true;
                }

                if (isError)
                {
                    MessageBox.Show("Произошла ошибка при очищении запрашиваемого файла. Возможно он открыт.");
                    return;
                }

                var swaggerResponse = await client.GetFileAsync(fileTableList.DocType, fileTableList.FileName, _currentUser.UserId);

                if (swaggerResponse != null && swaggerResponse.Result)
                {

                    Process.Start("explorer.exe", fileName);
                }
                else
                {
                    MessageBox.Show("ошибка");
                }

            }
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginText.Text))
            {
                toolStripStatusLabel1.Text = _noLoginStripStatus;
                _isLogin = false;
                return;
            }

            var client = JurClientService.JurDocsClientFactory();

            var user = await client.UsersAsync(new UserRequest { UserName = LoginText.Text });

            if (user.StatusCode == 200 && user.Result != null)
            {

                toolStripStatusLabel1.Text = "OK";
                _isLogin = true;
                _currentUser = user.Result;
                //LoginText.Items.Clear();
                dataGridView1.DataSource = null;
            }
        }


        private void testDataGrid()
        {
            var z = new List<FileTableList>();

            for (int i = 0; i < 10; i++)
                z.Add(new FileTableList { Id = i, DocType = "d1" + i, BtnText = "btn" + i });

            this.dataGridView1.DataSource = z;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fileTableListBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Нужно залогинится", "Сообщение");
                return;
            }

            var client = JurClientService.JurDocsClientFactory();
            var response = await client.DocumentListGETAsync(_currentUser.UserId);

            var fileTableLists = new List<FileTableList>();

            var k = 1;
            foreach (var item in response.Result)
            {
                fileTableLists.Add(new FileTableList
                {
                    Id = k,
                    DocType = item.DocName,
                    BtnText = "открыть",
                    FileName = item.FileName
                });
                k++;
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = fileTableLists;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Нужно залогинится", "Сообщение");
                return;
            }

            var client = JurClientService.JurDocsClientFactory();
            var response = await client.DocumentListPOSTAsync(new DocumentListRequest { DocName = "Выписки", UserId = _currentUser.UserId });

            var fileTableLists = new List<FileTableList>();

            var k = 1;
            foreach (var item in response.Result)
            {
                fileTableLists.Add(new FileTableList { Id = k, DocType = item.DocName, BtnText = "открыть", FileName = item.FileName });
                k++;
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = fileTableLists;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Нужно залогинится", "Сообщение");
                return;
            }

            var client = JurClientService.JurDocsClientFactory();
            var response = await client.DocumentListPOSTAsync(new DocumentListRequest { DocName = "Договоры", UserId = _currentUser.UserId });

            var fileTableLists = new List<FileTableList>();

            var k = 1;
            foreach (var item in response.Result)
            {
                fileTableLists.Add(new FileTableList { Id = k, DocType = "Договоры", BtnText = "открыть", FileName = item.FileName });
                k++;
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = fileTableLists;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            const string DocName = "Справки";

            if (_currentUser == null)
            {
                MessageBox.Show("Нужно залогинится", "Сообщение");
                return;
            }

            var client = JurClientService.JurDocsClientFactory();
            var response = await client.DocumentListPOSTAsync(new DocumentListRequest { DocName = DocName, UserId = _currentUser.UserId });

            var fileTableLists = new List<FileTableList>();

            var k = 1;
            foreach (var item in response.Result)
            {
                fileTableLists.Add(new FileTableList
                {
                    Id = k,
                    DocType = item.DocName,
                    BtnText = "открыть",
                    FileName = item.FileName
                });
                k++;
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = fileTableLists;
        }
    }
}
