using Autofac;
using JurDocs.Client;
using JurDocs.Core;
using JurDocs.Core.DI;
using JurDocs.Core.Views;
using JurDocs.WinForms.ViewModel;

namespace JurDocsWinForms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AddNewDoc : Form, IDocEditor
    {

        public AddNewDoc()
        {
            InitializeComponent();
        }

        private void AddNewDoc_Load(object sender, EventArgs e)
        {
            MinimumSize = new Size(Width, Height);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dialogResult = openFileDialog1.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
                textBoxFileName.Text = openFileDialog1.FileName;
        }

        public void SetData(LetterDocument data)
        {
            throw new NotImplementedException();
        }

        LetterDocument IDocEditor.GetData()
        {
            throw new NotImplementedException();
        }
    }
}
