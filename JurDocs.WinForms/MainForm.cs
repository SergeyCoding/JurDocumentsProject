using Autofac;
using JurDocs.Client;
using JurDocs.Core;
using JurDocs.Core.Commands;
using JurDocs.Core.DI;
using JurDocs.Core.Model;
using JurDocs.Core.Views;
using JurDocs.WinForms;
using JurDocs.WinForms.DI;
using JurDocs.WinForms.Model;
using JurDocs.WinForms.Supports;
using JurDocs.WinForms.ViewModel;
using JurDocsWinForms.Model;
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
                throw new InvalidOperationException("������������ �� ��������������");

            ViewModel = new MainViewModel(JurClientService.JurDocsClientFactory(WorkSession.User.Token));

            toolStripStatusLabel1.Text = $"������������: {WorkSession.User.UserName}";

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
            button1.MouseUp += button1_MouseDown;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

            await UpdateProjectList();


            var changeCurrentPage = CoreContainer.Get().Resolve<IChangeCurrentPage>();
            await changeCurrentPage.ExecuteAsync("������");

            var state = CoreContainer.Get().Resolve<IGetState>();
            tssCurrentPage.Text = $"������� ������: {state.GetCurrentPage}";
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
                var ftl = (List<FileTableList>)dgvProjects.DataSource;

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
                    MessageBox.Show("��������� ������ ��� �������� �������������� �����. �������� �� ������.");
                    return;
                }

                var swaggerResponse = await client.DocumentFileGETAsync("", fileTableList.DocType, fileTableList.FileName);

                if (swaggerResponse != null && swaggerResponse.Result)
                {

                    Process.Start("explorer.exe", fileName);
                }
                else
                {
                    MessageBox.Show("������");
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
                MessageBox.Show("����� �����������", "���������");
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
                    BtnText = "�������",
                    FileName = item.FileName
                });
                k++;
            }
            dgvProjects.AutoGenerateColumns = false;
            dgvProjects.DataSource = null;
            dgvProjects.DataSource = fileTableLists;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (WorkSession?.User == null)
            {
                MessageBox.Show("����� �����������", "���������");
                return;
            }

            var client = JurClientService.JurDocsClientFactory();
            var response = await client.DocumentListPOSTAsync(new DocumentListRequest { DocName = "�������", });

            var fileTableLists = new List<FileTableList>();

            var k = 1;
            foreach (var item in response.Result)
            {
                fileTableLists.Add(new FileTableList { Id = k, DocType = item.DocName, BtnText = "�������", FileName = item.FileName });
                k++;
            }
            dgvProjects.AutoGenerateColumns = false;
            dgvProjects.DataSource = null;
            dgvProjects.DataSource = fileTableLists;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (WorkSession?.User == null)
            {
                MessageBox.Show("����� �����������", "���������");
                return;
            }

            var client = JurClientService.JurDocsClientFactory();
            var response = await client.DocumentListPOSTAsync(new DocumentListRequest { DocName = "��������" });

            var fileTableLists = new List<FileTableList>();

            var k = 1;
            foreach (var item in response.Result)
            {
                fileTableLists.Add(new FileTableList { Id = k, DocType = "��������", BtnText = "�������", FileName = item.FileName });
                k++;
            }
            dgvProjects.AutoGenerateColumns = false;
            dgvProjects.DataSource = null;
            dgvProjects.DataSource = fileTableLists;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            const string DocName = "�������";

            if (WorkSession?.User == null)
            {
                MessageBox.Show("����� �����������", "���������");
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
                    BtnText = "�������",
                    FileName = item.FileName
                });
                k++;
            }
            dgvProjects.AutoGenerateColumns = false;
            dgvProjects.DataSource = null;
            dgvProjects.DataSource = fileTableLists;
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //private async void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var createProjectViewModel = await ViewModel!.CreateNewProject();

        //    var f = new CreateProjectForm { ViewModel = createProjectViewModel! };

        //    ProgramHelpers.MoveWindowToCenterScreen(f);
        //    f.ShowDialog(this);
        //}

        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void newToolStripButton_Click(object sender, EventArgs e)
        {
            await CoreContainer.Get<ICreateProjectOrDocument>().ExecuteAsync(this);
        }

        private async void cutToolStripButton_Click(object sender, EventArgs e)
        {
            await UpdateProjectList();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private async void tabControl1_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            var state = CoreContainer.Get().Resolve<IGetState>();

            if (sender is TabControl tc)
            {
                var text = tc.SelectedTab?.Text;

                var changeCurrentPage = CoreContainer.Get().Resolve<IChangeCurrentPage>();

                await changeCurrentPage.ExecuteAsync(text!);


                tssCurrentPage.Text = $"������� ������: {state.GetCurrentPage}";
            }

            if (state.GetCurrentPage == JurDocs.Core.Constants.AppPage.������)
            {
                cbProjectList.Items.Clear();

                var projectNameList = await ViewModel.GetProjectNameList();

                if (projectNameList.Any())
                {
                    cbProjectList.Items.AddRange(projectNameList);
                    cbProjectList.Text = state.GetCurrentProject.Name;
                }
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
            tssCurrentProject.Text = $"������� ������: {state.GetCurrentProject.Name}";
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

        private async void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await CoreContainer.Get<ICreateProject>().CreateNewProject(this);
        }

        public void OpenDocEditor(LetterDocument data)
        {
            var docEditor = Views.Container().Resolve<IDocEditor>();
            docEditor.SetData(data);

            (docEditor as Form)?.ShowDialog(this);

        }
    }
}
