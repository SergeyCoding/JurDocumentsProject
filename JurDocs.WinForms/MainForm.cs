using Autofac;
using JurDocs.Client;
using JurDocs.Core;
using JurDocs.Core.Commands;
using JurDocs.Core.Commands.Project;
using JurDocs.Core.Commands.Projects;
using JurDocs.Core.DI;
using JurDocs.Core.Model;
using JurDocs.Core.Views;
using JurDocs.WinForms;
using JurDocs.WinForms.DI;
using JurDocs.WinForms.Model;
using JurDocs.WinForms.Supports;
using JurDocs.WinForms.ViewModel;
using JurDocsWinForms.Model;
using PDFtoImage;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace JurDocsWinForms
{
    [SuppressMessage("Style", "IDE1006:Naming Styles")]

    public partial class MainForm : Form, IProjectListView, IMainView
    {
        public required MainViewModel ViewModel { get; set; }

        public required WorkSession WorkSession { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (WorkSession == null)
                throw new InvalidOperationException("Пользователь не зарегистррован");

            ViewModel = new MainViewModel(JurClientService.JurDocsClientFactory(WorkSession.User.Token));

            toolStripStatusLabel1.Text = $"Пользователь: {WorkSession.User.UserName}";

            MinimumSize = new Size(Width, Height);

            panelDragDrop.AllowDrop = true;
            panelDragDrop.AllowDrop = true;

            panelDragDrop.BorderStyle = BorderStyle.FixedSingle;
            panelDragDrop.BorderStyle = BorderStyle.FixedSingle;

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            panelDragDrop.DragEnter += panel_DragEnter;
            panelDocs.DragEnter += panel_DragEnter;
            panelDragDrop.DragDrop += panel_DragDrop;
            panelDocs.DragDrop += panel_DragDrop;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

            await UpdateProjectList();


            var changeCurrentPage = CoreContainer.Get().Resolve<IChangeCurrentPage>();
            await changeCurrentPage.ExecuteAsync("Проект");

            var state = CoreContainer.Get().Resolve<IGetState>();
            tssCurrentPage.Text = $"Текущий раздел: {state.GetCurrentPage}";
        }



        public async Task UpdateProjectList()
        {
            if (ViewModel == null)
                return;

            var projectList = await ViewModel.GetProjectList();

            dgvProjectList.DataSource = new SortableBindingList<ProjectListTable>(projectList);
            dgvProjectList.ShowCellToolTips = false;
            dgvProjectList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProjectList.MultiSelect = false;

            var state = CoreContainer.Get().Resolve<IGetState>();

            var curProject = state.GetCurrentProject;

            if (curProject == null)
                return;

            for (int i = 0; i < projectList.Length; i++)
            {
                if (projectList[i].Id == curProject.Id)
                {
                    dgvProjectList.CurrentCell = dgvProjectList.Rows[i].Cells[0];
                    break;
                }
            }
        }

        public async Task UpdateLetterDocsList(LetterDocument[] letterDocuments)
        {
            if (ViewModel == null)
                return;

            var enumerable = letterDocuments.Select(x => new LetterDocsListTable { Id = x.Id });

            var projectList = new List<LetterDocsListTable>();
            projectList.AddRange(enumerable);

            dgvLetterDocsList.DataSource = new SortableBindingList<LetterDocsListTable>(projectList);
            dgvLetterDocsList.ShowCellToolTips = false;
            dgvLetterDocsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLetterDocsList.MultiSelect = false;

            //var state = CoreContainer.Get().Resolve<IGetState>();

            //var curProject = state.GetCurrentProject;

            //if (curProject == null)
            //    return;

            //for (int i = 0; i < projectList.Length; i++)
            //{
            //    if (projectList[i].Id == curProject.Id)
            //    {
            //        dgvLetterDocsList.CurrentCell = dgvLetterDocsList.Rows[i].Cells[0];
            //        break;
            //    }
            //}
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
                        WorkSession.AddNewDoc(item);
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
                var ftl = (List<FileTableList>)dgvLetterDocsList.DataSource;

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
            dgvLetterDocsList.AutoGenerateColumns = false;
            dgvLetterDocsList.DataSource = null;
            dgvLetterDocsList.DataSource = fileTableLists;
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
            dgvLetterDocsList.AutoGenerateColumns = false;
            dgvLetterDocsList.DataSource = null;
            dgvLetterDocsList.DataSource = fileTableLists;
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
            dgvLetterDocsList.AutoGenerateColumns = false;
            dgvLetterDocsList.DataSource = null;
            dgvLetterDocsList.DataSource = fileTableLists;
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
            dgvLetterDocsList.AutoGenerateColumns = false;
            dgvLetterDocsList.DataSource = null;
            dgvLetterDocsList.DataSource = fileTableLists;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //private async void создатьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var createProjectViewModel = await ViewModel!.CreateNewProject();

        //    var f = new CreateProjectForm { ViewModel = createProjectViewModel! };

        //    ProgramHelpers.MoveWindowToCenterScreen(f);
        //    f.ShowDialog(this);
        //}

        private void изменитьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void ToolBtn_CreateCommand_Click(object sender, EventArgs e)
        {
            await CoreContainer.Get<ICreateProjectOrDocument>().ExecuteAsync(this);
        }

        private async void cutToolStripButton_Click(object sender, EventArgs e)
        {
            await UpdateProjectList();
        }

        private async void ToolBtn_OpenCommand_ClickAsync(object sender, EventArgs e)
        {
            await CoreContainer.Get<IOpenProjectOrDocument>().ExecuteAsync(this);
        }

        private async void tabControl1_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            var state = CoreContainer.Get().Resolve<IGetState>();

            if (sender is TabControl tc)
            {
                var text = tc.SelectedTab?.Text;

                var changeCurrentPage = CoreContainer.Get<IChangeCurrentPage>();

                await changeCurrentPage.ExecuteAsync(text!);


                tssCurrentPage.Text = $"Текущий раздел: {state.GetCurrentPage}";
            }

            if (state.GetCurrentPage == JurDocs.Core.Constants.AppPage.Письмо)
            {
                cbProjectList.Items.Clear();

                var projectNameList = await ViewModel.GetProjectNameList();

                if (projectNameList.Any())
                {
                    cbProjectList.Items.AddRange(projectNameList);
                    cbProjectList.Text = state.GetCurrentProject.Name;
                }

                var getDocumentList = CoreContainer.Get<IGetDocumentList>();
                var letterDocuments = await getDocumentList.ExecuteAsync();

                await UpdateLetterDocsList(letterDocuments);
            }
        }

        private async void dgvProjectList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProjectList.DataSource is SortableBindingList<ProjectListTable> projectListTables)
            {
                var projectListTable = projectListTables[e.RowIndex];

                var changeCurrentProject = CoreContainer.Get().Resolve<IChangeCurrentProject>();

                await changeCurrentProject.ExecuteAsync(this, projectListTable.Id);
            }
        }

        public Task SetCurrentProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public void ChangeCurrentProject(JurDocProject currentProject)
        {
            var state = CoreContainer.GetState();
            tssCurrentProject.Text = $"Текущий проект: {state.GetCurrentProject.Name}";
        }

        public async void OpenProjectEditor(EditedProjectData projDto)
        {
            var projectEditor = Views.Container().Resolve<IProjectEditor>();
            projectEditor.SetData(projDto);

            var projectEditorResult = (projectEditor as Form)?.ShowDialog(this);

            if (projectEditorResult == DialogResult.Cancel)
            {
                await CoreContainer.Get<IDeleteProject>().ExecuteAsync(projDto.ProjectId);
            }
            else if (projectEditorResult == DialogResult.OK)
            {
                var editedProjectData = projectEditor.GetData();
                await CoreContainer.Get<ISaveProject>().ExecuteAsync(editedProjectData);
            }

            await UpdateProjectList();
        }

        private async void создатьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await CoreContainer.Get<ICreateProject>().CreateNewProject(this);
        }

        public void OpenDocEditor(LetterDocument data)
        {
            var docEditor = Views.Container().Resolve<IDocEditor>();
            docEditor.SetData(data);

            (docEditor as Form)?.ShowDialog(this);

        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            //var bytes = File.ReadAllBytes(@"D:\Users\Downloads\3LKTB_3WGMS.pdf");

            //var v = Conversion.GetPageCount(bytes);
            //for (int i = 0; i < v; i++)
            //{
            //    Conversion.SaveJpeg($"D:\\TFS\\temp\\1_{("000" + i)[^3..]}.jpeg", bytes, null, i);
            //}
        }

        private async void dgvLetterDocsList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLetterDocsList.DataSource is SortableBindingList<LetterDocsListTable> letterTable)
            {
                var letterListTable = letterTable[e.RowIndex];

                var changeCurrentProject = CoreContainer.Get().Resolve<IChangeCurrentDocument>();

                await changeCurrentProject.ExecuteAsync(letterListTable.Id);
            }
        }
    }
}
