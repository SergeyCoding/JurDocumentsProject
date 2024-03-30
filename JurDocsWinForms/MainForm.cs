using JurDocsClient;
using JurDocsWinForms.Model;
using LexExchangeApi.Clients;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace JurDocsWinForms
{
    [SuppressMessage("Style", "IDE1006:Naming Styles")]

    public partial class MainForm : Form
    {
        private const string _noLoginStripStatus = "Выберите пользователя, и нажмите логин...";
        private UserResponse? _currentUser = null;

        internal WorkSession? WorkSession { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = _noLoginStripStatus;
            MinimumSize = new Size(Width, Height);

            panel1.AllowDrop = true;
            panel1.AllowDrop = true;

            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.BorderStyle = BorderStyle.FixedSingle;

            panel1.DragEnter += panel_DragEnter;
            panel2.DragEnter += panel_DragEnter;

            panel1.DragDrop += panel_DragDrop;
            panel2.DragDrop += panel_DragDrop;

            button1.MouseUp += button1_MouseDown;

        }

        void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.DoDragDrop(button1, DragDropEffects.Move);
        }

        void panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void panel_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var files = e.Data!.GetData(DataFormats.FileDrop);

                if (files != null && files is string[] fileList)
                {
                    foreach (var item in fileList)
                    {
                        WorkSession.AddNewDoc(item);
                    }

                }
            }
            catch (Exception)
            {
            }

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

                var swaggerResponse = await client.DocumentFileGETAsync(fileTableList.DocType, fileTableList.FileName, _currentUser.UserId);

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
                return;
            }

            var client = JurClientService.JurDocsClientFactory();

            var user = await client.UsersAsync(new UserRequest { UserName = LoginText.Text });

            if (user.StatusCode == 200 && user.Result != null)
            {

                toolStripStatusLabel1.Text = "OK";
                _currentUser = user.Result;
                dataGridView1.DataSource = null;
            }
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form f = new AddNewDoc();
            ProgramHelpers.MoveWindowToCenterScreen(f);
            f.ShowDialog(this);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
