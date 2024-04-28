using JurDocs.Core;
using JurDocs.WinForms.ViewModel;

namespace JurDocsWinForms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AddNewDoc : Form
    {
        public required AddNewDocViewModel ViewModel { get; set; }

        public AddNewDoc()
        {
            InitializeComponent();
        }

        private void AddNewDoc_Load(object sender, EventArgs e)
        {
            MinimumSize = new Size(Width, Height);

            var state = new GetState();

            cbProjectName.Items.Clear();
            cbProjectName.Text = state.GetCurrentProject.Name;

            if (state.GetCurrentPage == JurDocs.Core.Constants.AppPage.Письмо)
            {
                cbDocType.Text = "Письмо";
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dialogResult = openFileDialog1.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
                textBoxFileName.Text = openFileDialog1.FileName;
        }


    }
}
