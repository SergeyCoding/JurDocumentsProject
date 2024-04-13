using JurDocs.Common.EnumTypes;
using JurDocs.WinForms.ViewModel;

namespace JurDocsWinForms
{
    public partial class CreateProjectForm : Form
    {
        public required CreateProjectViewModel ViewModel { get; set; }

        public CreateProjectForm()
        {
            InitializeComponent();
        }

        private void CreateProjectForm_Load(object sender, EventArgs e)
        {
            if (ViewModel == null)
                return;

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

        private async void btnOk_Click(object sender, EventArgs e)
        {
            TopMost = false;

            ViewModel.ProjectName = tbProjectName.Text;
            ViewModel.ProjectFullName = tbProjectFullName.Text;

            await ViewModel.SaveProjectAsync();

            Close();

        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Закрыть окно проекта без сохранения?", "Проект", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                await ViewModel.DeleteProjectAsync();

                Close();
            }
        }
    }
}
