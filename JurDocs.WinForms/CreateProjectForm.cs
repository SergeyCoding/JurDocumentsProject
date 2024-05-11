using JurDocs.Common.EnumTypes;
using JurDocs.Core.Model;
using JurDocs.Core.Views;

namespace JurDocsWinForms
{
    public partial class CreateProjectForm : Form, IProjectEditor
    {

        private readonly List<EditedProjectData> _data = [];

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

        private static void LoadCheckListBox(CheckedListBox clb, IEnumerable<UserRight> rights, JurDocType docType)
        {
            foreach (var item in rights)
            {
                item.DocType = docType;

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

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Закрыть окно проекта без сохранения?",
                                "Проект",
                                MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }


        public void SetData(EditedProjectData projectData)
        {
            _data.Clear();
            _data.Add(projectData);

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
            var result = _data.First();

            result.ProjectName = tbProjectName.Text;
            result.ProjectFullName = tbProjectFullName.Text;

            LoadCheckListBox(clbProjectRights, result.ProjectRights, JurDocType.All);
            LoadCheckListBox(clbProjectRights_Справки, result.ProjectRights_Справки, JurDocType.Справка);
            LoadCheckListBox(clbProjectRights_Выписки, result.ProjectRights_Выписки, JurDocType.Выписка);

            return result;
        }
    }
}
