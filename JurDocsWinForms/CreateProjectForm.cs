using JurDocs.Common.EnumTypes;
using JurDocs.WinForms.ViewModel;

namespace JurDocsWinForms
{
    public partial class CreateProjectForm : Form
    {
        public CreateProjectViewModel? ViewModel { get; set; }

        public CreateProjectForm()
        {
            InitializeComponent();
        }

        private void CreateProjectForm_Load(object sender, EventArgs e)
        {
            if (ViewModel == null)
                return;

            tbProjectId.Text = ViewModel.ProjectName;
            tbProjectNote.Text = ViewModel.ProjectFullName;
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

        private void btnOk_Click(object sender, EventArgs e)
        {


            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
