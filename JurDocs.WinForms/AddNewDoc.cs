using JurDocs.Client;
using JurDocs.Core.Model;
using JurDocs.Core.Views;
using PDFtoImage;

namespace JurDocsWinForms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AddNewDoc : Form, IDocEditor
    {
        public int CurrentPage { get; set; }

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
            comboBox9.Text = data.Sender[9];

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
        }

        public EditedDocData GetData()
        {
            return new EditedDocData();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void BtnPageBack_Click(object sender, EventArgs e)
        {
            var bytes = File.ReadAllBytes(@"D:\Users\Downloads\3LKTB_3WGMS.pdf");

            var pages = Conversion.GetPageCount(bytes);
            var sizeF = Conversion.GetPageSize(bytes, CurrentPage);

            CurrentPage--;
            if (CurrentPage < 0)
                CurrentPage = 0;

            btnPageBack.Enabled = CurrentPage > 0;
            btnPageNext.Enabled = CurrentPage < pages - 1;


            UpdatePreview(bytes, sizeF);
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
            var bytes = File.ReadAllBytes(@"D:\Users\Downloads\3LKTB_3WGMS.pdf");

            var pages = Conversion.GetPageCount(bytes);
            var sizeF = Conversion.GetPageSize(bytes, CurrentPage);

            CurrentPage++;
            if (CurrentPage >= pages - 1)
            {
                CurrentPage = pages - 1;
                btnPageNext.Enabled = false;
            }

            btnPageBack.Enabled = CurrentPage > 0;
            btnPageNext.Enabled = CurrentPage < pages - 1;

            UpdatePreview(bytes, sizeF);
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {

        }

        private void BtnOkClick(object sender, EventArgs e)
        {

        }
    }
}
