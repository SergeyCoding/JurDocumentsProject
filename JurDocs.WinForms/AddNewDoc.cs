using JurDocs.Common.EnumTypes;
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

        private EditedDocData _editedDocData;

        public CloseEditorType CloseType { get; set; }

        public AddNewDoc()
        {
            InitializeComponent();
        }

        private void AddNewDoc_Load(object sender, EventArgs e)
        {
            MinimumSize = new Size(Width, Height);
            _lastWindowState = WindowState;
        }

        public void SetData(EditedDocData data)
        {
            _editedDocData = data;

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
            if (DateTime.TryParse(tbDateIn.Text, out var dateTimeIn))
            {

            }

            _ = DateTime.TryParse(tbDateOut.Text, out var dateTimeOut);

            return new EditedDocData
            {
                Id = _editedDocData.Id,
                CloseType = CloseType,
                DateIncoming = dateTimeIn,
                DateOutgoing = dateTimeOut,
                DocName = tbCaption.Text,
                DocType = _editedDocData.DocType,
                ExecutivePerson = _editedDocData.ExecutivePerson,
                FileName = _pdfPreview.FileName,
                IsDeleted = _editedDocData.IsDeleted,
                NumberIncoming = tbNumberIn.Text,
                NumberOutgoing = tbNumberOut.Text,
                ProjectId = _editedDocData.ProjectId,
            };
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

            if (_pdfPreview.IsExistsPreview)
                statusPageCountText.Text = $"Страница: {_pdfPreview.CurrentPage + 1}/{_pdfPreview.TotalPage}";
            else
                statusPageCountText.Text = "Не выбран скан документа";
        }



        private void BtnPageNext_Click(object sender, EventArgs e)
        {
            _pdfPreview.GoPageNext();
            UpdateFormInfo();
            UpdatePreview();
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
                tbSourceFileName.Text = dragDropFileName.FileName;
                tbFileName.Text = dragDropFileName.FileName;
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

        private void AddNewDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dialogResult = MessageBox.Show("Закрыть без сохранения документа?", "Отмена", MessageBoxButtons.YesNoCancel);

            if (dialogResult != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Сохранить документ?", "Сохранение", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                CloseType = CloseEditorType.Save;
                FormClosing -= AddNewDoc_FormClosing!;
                Close();
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Закрыть без сохранения документа?", "Отмена", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                CloseType = CloseEditorType.Cancel;
                FormClosing -= AddNewDoc_FormClosing!;
                Close();
            }
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Удалить документ?", "Удаление", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                CloseType = CloseEditorType.Delete;
                FormClosing -= AddNewDoc_FormClosing!;
                Close();
            }
        }

        private void AddNewDoc_ResizeEnd(object sender, EventArgs e)
        {
            UpdatePreview();
        }


    }
}
