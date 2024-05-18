using JurDocs.Core.Model;
using JurDocs.Core.Views;
using JurDocs.WinForms.Service;
using PDFtoImage;

namespace JurDocsWinForms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AddNewDoc : Form, IDocEditor
    {
        private string FileName { get; set; } = string.Empty;

        public int CurrentPage { get; set; }

        private FormWindowState _lastWindowState;


        public AddNewDoc()
        {
            InitializeComponent();
        }

        private void AddNewDoc_Load(object sender, EventArgs e)
        {
            MinimumSize = new Size(Width, Height);
            _lastWindowState = WindowState;
            btnPageBack.Enabled = false;
            btnPageNext.Enabled = false;
            statusPageCountText.Text = "Не выбран скан документа";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dialogResult = openFileDialog1.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
                tbDateOut.Text = openFileDialog1.FileName;
        }

        public void SetData(EditedDocData data)
        {
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

            FileName = data.FileName ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(FileName))
            {
                CurrentPage = 0;
                BtnPageBack_Click(this, EventArgs.Empty);
            }
        }

        public EditedDocData GetData()
        {
            return new EditedDocData();
        }


        private void BtnPageBack_Click(object sender, EventArgs e)
        {
            var bytes = File.ReadAllBytes(FileName);

            var pages = Conversion.GetPageCount(bytes);
            var sizeF = Conversion.GetPageSize(bytes, CurrentPage);

            CurrentPage--;
            if (CurrentPage < 0)
                CurrentPage = 0;

            UpdateFormInfo(CurrentPage + 1, pages);

            UpdatePreview(bytes, sizeF);
        }

        private void UpdateFormInfo(int currentPage, int pages)
        {
            btnPageBack.Enabled = currentPage > 1;
            btnPageNext.Enabled = currentPage < pages;
            statusPageCountText.Text = $"Страница: {currentPage}/{pages}";
        }

        private void UpdatePreview(byte[] bytes, SizeF sizeF)
        {
            double kW = pbViewer.Width / sizeF.Width;
            double kH = pbViewer.Height / sizeF.Height;

            var k = Math.Min(kH, kW) * .95;


            var options = new RenderOptions
            {
                Width = (int)(sizeF.Width * k),
                Height = (int)(sizeF.Height * k),
            };

            using (var memoryStream = new MemoryStream())
            {
                Conversion.SaveJpeg(memoryStream, bytes, null, CurrentPage, options);
                var image = Image.FromStream(memoryStream);

                pbViewer.Image = image;
            }
        }

        private void BtnPageNext_Click(object sender, EventArgs e)
        {
            var bytes = File.ReadAllBytes(FileName);

            var pages = Conversion.GetPageCount(bytes);
            var sizeF = Conversion.GetPageSize(bytes, CurrentPage);

            CurrentPage++;
            if (CurrentPage >= pages - 1)
            {
                CurrentPage = pages - 1;
                btnPageNext.Enabled = false;
            }

            UpdateFormInfo(CurrentPage + 1, pages);

            UpdatePreview(bytes, sizeF);
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
                FileName = dragDropFileName.FileName;
                CurrentPage = 0;
                BtnPageBack_Click(sender, e);
            }
        }

        private void AddNewDoc_Resize(object sender, EventArgs e)
        {
            splitDocForm.SplitterDistance = splitDocForm.Panel1MinSize;

            if (WindowState != _lastWindowState)
            {
                _lastWindowState = WindowState;

                if (!string.IsNullOrEmpty(FileName))
                {
                    CurrentPage++;
                    BtnPageBack_Click(sender, e);
                }
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {

        }

        private void AddNewDoc_ResizeEnd(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FileName))
            {
                CurrentPage++;
                BtnPageBack_Click(sender, e);
            }
        }
    }
}
