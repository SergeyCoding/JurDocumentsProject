using JurDocs.Client;
using JurDocs.Common.EnumTypes;
using JurDocs.WinForms;
using JurDocs.WinForms.ViewModel;
using JurDocsWinForms.Model;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace JurDocsWinForms
{
    [SuppressMessage("Style", "IDE1006:Naming Styles")]

    public partial class MainForm : Form
    {
        internal WorkSession? WorkSession { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (WorkSession?.User != null)
            {
                toolStripStatusLabel1.Text = $"Пользователь: {WorkSession.User.UserName}";
            }
            MinimumSize = new Size(Width, Height);

            panel1.AllowDrop = true;
            panel1.AllowDrop = true;

            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.BorderStyle = BorderStyle.FixedSingle;

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            panel1.DragEnter += panel_DragEnter;
            panel2.DragEnter += panel_DragEnter;
            panel1.DragDrop += panel_DragDrop;
            panel2.DragDrop += panel_DragDrop;
            button1.MouseUp += button1_MouseDown;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        WorkSession.AddNewDoc(item);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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

                var fileName = Path.Combine(WorkSession!.User.TempDir, fileTableList.FileName!);

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

                var swaggerResponse = await client.DocumentFileGETAsync("", fileTableList.DocType, fileTableList.FileName);

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

        private void Login_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(LoginText.Text))
            //{
            //    toolStripStatusLabel1.Text = _noLoginStripStatus;
            //    return;
            //}

            //var client = JurClientService.JurDocsClientFactory();

            //var user = await client.UsersAsync(new UserRequest { UserName = LoginText.Text });

            //if (user.StatusCode == 200 && user.Result != null)
            //{

            //    toolStripStatusLabel1.Text = "OK";
            //    _currentUser = user.Result;
            //    dataGridView1.DataSource = null;
            //}
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
            if (WorkSession!.User == null)
            {
                MessageBox.Show("Нужно залогинится", "Сообщение");
                return;
            }

            var client = JurClientService.JurDocsClientFactory();
            var response = await client.DocumentListGETAsync();

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
            if (WorkSession?.User == null)
            {
                MessageBox.Show("Нужно залогинится", "Сообщение");
                return;
            }

            var client = JurClientService.JurDocsClientFactory();
            var response = await client.DocumentListPOSTAsync(new DocumentListRequest { DocName = "Выписки", });

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
            if (WorkSession?.User == null)
            {
                MessageBox.Show("Нужно залогинится", "Сообщение");
                return;
            }

            var client = JurClientService.JurDocsClientFactory();
            var response = await client.DocumentListPOSTAsync(new DocumentListRequest { DocName = "Договоры" });

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

            if (WorkSession?.User == null)
            {
                MessageBox.Show("Нужно залогинится", "Сообщение");
                return;
            }

            var client = JurClientService.JurDocsClientFactory();
            var response = await client.DocumentListPOSTAsync(new DocumentListRequest { DocName = DocName });

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

        private async void создатьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var client = JurClientService.JurDocsClientFactory(WorkSession!.User.Token);

            var swaggerResponse = await client.ProjectPOSTAsync();

            var persons = await client.PersonAsync();

            var result = swaggerResponse.Result;

            var createProjectViewModel = new CreateProjectViewModel(client)
            {
                ProjectId = result.Id,
                ProjectName = result.Name,
                ProjectFullName = result.FullName,
                ProjectOwnerId = result.OwnerId,
                ProjectOwnerName = WorkSession.User.UserName!,
            };

            foreach (var person in persons.Result)
            {
                createProjectViewModel.ProjectRights.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });

                createProjectViewModel.ProjectRights_Справки.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });

                createProjectViewModel.ProjectRights_Выписки.Add(new UserRight
                {
                    UserId = person.PersonId,
                    UserName = person.PersonName,
                    Right = UserRightType.NotAllow
                });
            }

            var f = new CreateProjectForm { ViewModel = createProjectViewModel };

            ProgramHelpers.MoveWindowToCenterScreen(f);
            f.ShowDialog(this);
        }

        private void изменитьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
