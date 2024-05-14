using JurDocs.Core.Model;
using JurDocs.Core.Views;
using PDFtoImage;
using System.IO;

namespace JurDocsWinForms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AddNewDoc : Form, IDocEditor
    {
        private string FileName { get; set; } = @"D:\Users\Downloads\3LKTB_3WGMS.pdf";

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
            var bytes = File.ReadAllBytes(FileName);

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
            var bytes = File.ReadAllBytes(FileName);

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

        private void PbViewer_DragDrop(object sender, DragEventArgs e)
        {
            FileName = "e.Data.GetData";
            CurrentPage = 0;
            BtnPageBack_Click(sender, e);
        }

        private void PbViewer_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            toolStripStatusLabel1.Text = "0";

            //string filename;
            //validData = GetFilename(out filename, e);
            //if (validData)
            //{
            //    path = filename;
            //    getImageThread = new Thread(new ThreadStart(LoadImage));
            //    getImageThread.Start();
            //}
            //else
            //    e.Effect = DragDropEffects.None;

        }

        //private void PbViewer_DragOver(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;
        //    toolStripStatusLabel1.Text = "1";
        //}

        //private void TextBox1_DragOver(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Copy;
        //    toolStripStatusLabel1.Text = "2";
        //}

        //private void TextBox1_DragDrop(object sender, DragEventArgs e)
        //{
        //    toolStripStatusLabel1.Text = "3";
        //}

        private void SplitContainer1_Panel2_DragOver(object sender, DragEventArgs e)
        {
            toolStripStatusLabel1.Text = "4";
            e.Effect = DragDropEffects.Move;
        }

        private static bool GetFilename(out string filename, DragEventArgs e)
        {
            filename = string.Empty;

            if (e.Data == null)
                return false;

            bool result = false;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                if (e.Data.GetData("FileDrop") is Array data)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is string))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();

                        string[] extList = [".jpg", ".png", ".bmp", ".pdf"];

                        if (extList.Any(x => x == ext))
                            result = true;
                    }
                }
            }
            return result;
        }

        private void SplitContainer1_Panel2_DragDrop(object sender, DragEventArgs e)
        {
            if (GetFilename(out var f, e))
            {
                toolStripStatusLabel1.Text = f;
                FileName = f;
                CurrentPage = 0;
                BtnPageBack_Click(sender, e);
            }
        }
    }
}
