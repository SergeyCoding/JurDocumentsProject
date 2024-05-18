using JurDocs.Core.Model;
using JurDocs.Core.Views;
using JurDocs.WinForms.Model;
using JurDocs.WinForms.Service;

namespace JurDocsWinForms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AddNewDoc : Form, IDocEditor
    {
        private readonly PdfPreview _pdfPreview = new();

        private FormWindowState _lastWindowState;

        private Image? _defaultImage;


        public AddNewDoc()
        {
            InitializeComponent();
        }

        private void AddNewDoc_Load(object sender, EventArgs e)
        {
            MinimumSize = new Size(Width, Height);
            _lastWindowState = WindowState;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dialogResult = openFileDialog1.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
                tbDateOut.Text = openFileDialog1.FileName;
        }

        public void SetData(EditedDocData data)
        {
            _defaultImage = pbViewer.Image;

            cbProjectName.Items.Clear();
            cbProjectName.Text = data.ProjectName;

            cbDocType.Items.Clear();
            cbDocType.Text = data.DocType.ToString();

            tbCaption.Text = data.DocName;

            cbExecutors.Text = string.Empty;

            tbDateOut.Text = data.DateOutgoing.ToString();
            tbDateIn.Text = data.DateIncoming.ToString();

            tbNumberOut.Text = data.NumberOutgoing;
            tbNumberIn.Text = data.NumberIncoming;

            cbSender0.Text = data.Sender[0];
            cbSender1.Text = data.Sender[1];
            cbSender2.Text = data.Sender[2];
            cbSender3.Text = data.Sender[3];
            cbSender4.Text = data.Sender[4];
            cbSender5.Text = data.Sender[5];
            cbSender6.Text = data.Sender[6];
            cbSender7.Text = data.Sender[7];
            cbSender8.Text = data.Sender[8];
            cbSender9.Text = data.Sender[9];

            cbRecipient0.Text = data.Recipient[0];
            cbRecipient1.Text = data.Recipient[1];
            cbRecipient2.Text = data.Recipient[2];
            cbRecipient3.Text = data.Recipient[3];
            cbRecipient4.Text = data.Recipient[4];
            cbRecipient5.Text = data.Recipient[5];
            cbRecipient6.Text = data.Recipient[6];
            cbRecipient7.Text = data.Recipient[7];
            cbRecipient8.Text = data.Recipient[8];
            cbRecipient9.Text = data.Recipient[9];

            _pdfPreview.Init(data.FileName);
            UpdateFormInfo();
            UpdatePreview();
        }

        public EditedDocData GetData()
        {
            return new EditedDocData();
        }


        private void BtnPageBack_Click(object sender, EventArgs e)
        {
            _pdfPreview.GoPageBack();
            UpdateFormInfo();
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            if (_pdfPreview.IsExistsPreview)
                pbViewer.Image = _pdfPreview.GetImageForRect(pbViewer.Width, pbViewer.Height);
            else
                pbViewer.Image = _defaultImage;
        }

        private void UpdateFormInfo()
        {
            btnPageBack.Enabled = _pdfPreview.CanBack;
            btnPageNext.Enabled = _pdfPreview.CanNext;
            statusPageCountText.Text = $"Страница: {_pdfPreview.CurrentPage + 1}/{_pdfPreview.TotalPage}";
        }



        private void BtnPageNext_Click(object sender, EventArgs e)
        {
            _pdfPreview.GoPageNext();
            UpdateFormInfo();
            UpdatePreview();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {

        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {

        }

        private void SplitDocForm_Panel2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void SplitDocForm_Panel2_DragDrop(object sender, DragEventArgs e)
        {
            var dragDropFileName = new DragDropFileName(e.Data);
            dragDropFileName.Execute();

            if (dragDropFileName.IsOk)
            {
                _pdfPreview.Init(dragDropFileName.FileName);
                UpdateFormInfo();
                UpdatePreview();
            }
        }

        private void AddNewDoc_Resize(object sender, EventArgs e)
        {
            splitDocForm.SplitterDistance = splitDocForm.Panel1MinSize;

            if (WindowState != _lastWindowState)
            {
                _lastWindowState = WindowState;
                UpdatePreview();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {

        }

        private void AddNewDoc_ResizeEnd(object sender, EventArgs e)
        {
            UpdatePreview();
        }
    }
}
