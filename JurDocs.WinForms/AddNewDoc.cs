using JurDocs.Client;
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
                textBoxFileName.Text = openFileDialog1.FileName;
        }

        public void SetData(LetterDocument data)
        {
        }

        public LetterDocument GetData()
        {
            return new LetterDocument();
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
    }
}
