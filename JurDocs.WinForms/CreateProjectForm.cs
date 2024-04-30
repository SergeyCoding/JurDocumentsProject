using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.Views;
using JurDocs.WinForms.ViewModel;

namespace JurDocsWinForms
{
    public partial class CreateProjectForm : Form, IProjectEditor
    {
        public required CreateProjectViewModel ViewModel { get; set; }

        public CreateProjectForm()
        {
            InitializeComponent();
        }

        private async void CreateProjectForm_Load(object sender, EventArgs e)
        {
            if (ViewModel == null)
                return;

            await ViewModel.InitNewProject();

            tbProjectName.Text = ViewModel.ProjectName;
            tbProjectFullName.Text = ViewModel.ProjectFullName;
            cbProjectOwner.Text = ViewModel.ProjectOwnerName;
            cbProjectOwner.Items.Add(ViewModel.ProjectOwnerName);

            FillCheckListBox(clbProjectRights, ViewModel.ProjectRights);
            FillCheckListBox(clbProjectRights_Справки, ViewModel.ProjectRights_Справки);
            FillCheckListBox(clbProjectRights_Выписки, ViewModel.ProjectRights_Выписки);
        }


        private static void FillCheckListBox(CheckedListBox clb, IEnumerable<UserRight> rights)
        {
            clb.Items.Clear();

            foreach (var item in rights)
            {
                var n = clb.Items.Add(item.UserName);

                if (item.Right == UserRightType.Allow)
                    clb.SetItemCheckState(n, CheckState.Checked);
            }
        }

        private static void LoadCheckListBox(CheckedListBox clb, IEnumerable<UserRight> rights)
        {
            foreach (var item in rights)
            {
                if (clb.CheckedItems.Contains(item.UserName))
                {
                    item.Right = UserRightType.Allow;
                }
                else
                {
                    item.Right = UserRightType.NotAllow;
                }
            }
        }

        private async void BtnOk_Click(object sender, EventArgs e)
        {
            TopMost = false;

            ViewModel.ProjectName = tbProjectName.Text;
            ViewModel.ProjectFullName = tbProjectFullName.Text;

            LoadCheckListBox(clbProjectRights, ViewModel.ProjectRights);
            LoadCheckListBox(clbProjectRights_Справки, ViewModel.ProjectRights_Справки);
            LoadCheckListBox(clbProjectRights_Выписки, ViewModel.ProjectRights_Выписки);

            await ViewModel.SaveProjectAsync();

            Close();
        }

        private async void BtnCancel_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Закрыть окно проекта без сохранения?", "Проект", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                await ViewModel.DeleteProjectAsync();

                Close();
            }
        }

        public void Open(EditedProject projDto)
        {

        }
    }
}
