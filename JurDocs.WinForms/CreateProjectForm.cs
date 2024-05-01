using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.Views;

namespace JurDocsWinForms
{
    public partial class CreateProjectForm : Form, IProjectEditor
    {
        public CreateProjectForm()
        {
            InitializeComponent();
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

            //ViewModel.ProjectName = tbProjectName.Text;
            //ViewModel.ProjectFullName = tbProjectFullName.Text;

            //LoadCheckListBox(clbProjectRights, ViewModel.ProjectRights);
            //LoadCheckListBox(clbProjectRights_Справки, ViewModel.ProjectRights_Справки);
            //LoadCheckListBox(clbProjectRights_Выписки, ViewModel.ProjectRights_Выписки);

            //await ViewModel.SaveProjectAsync();

            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Закрыть окно проекта без сохранения?", "Проект", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                //await ViewModel.DeleteProjectAsync();

                Close();
            }
        }

        public void SetData(EditedProjectData projectData)
        {
            tbProjectName.Text = projectData.ProjectName;
            tbProjectFullName.Text = projectData.ProjectFullName;
            cbProjectOwner.Text = projectData.ProjectOwnerName;
            cbProjectOwner.Items.Add(projectData.ProjectOwnerName);

            FillCheckListBox(clbProjectRights, projectData.ProjectRights);
            FillCheckListBox(clbProjectRights_Справки, projectData.ProjectRights_Справки);
            FillCheckListBox(clbProjectRights_Выписки, projectData.ProjectRights_Выписки);
        }

        public EditedProjectData GetData()
        {
            throw new NotImplementedException();
        }
    }
}
