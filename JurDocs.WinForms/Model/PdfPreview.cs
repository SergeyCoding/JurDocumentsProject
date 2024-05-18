using PDFtoImage;

namespace JurDocs.WinForms.Model
{
    internal sealed class PdfPreview
    {
        public int CurrentPage { get; private set; }
        public int TotalPage => _pages;
        public bool CanBack => CurrentPage > 0;
        public bool CanNext => CurrentPage < _pages - 1;
        public string FileName { get; private set; } = string.Empty;
        public bool IsExistsPreview => _pages > 0;

        private byte[]? _bytes;
        private int _pages;
        private SizeF _sizeF;
        internal void Init(string? fileName)
        {
            CurrentPage = 0;
            _pages = 0;
            _bytes = null;

            FileName = fileName ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                _bytes = File.ReadAllBytes(FileName);
                _pages = Conversion.GetPageCount(_bytes);
                _sizeF = Conversion.GetPageSize(_bytes, CurrentPage);
            }
        }

        public void GoPageBack()
        {
            if (_bytes == null)
                return;

            _sizeF = Conversion.GetPageSize(_bytes, CurrentPage);

            CurrentPage--;
            if (CurrentPage < 0)
                CurrentPage = 0;
        }

        public void GoPageNext()
        {
            if (_bytes == null)
                return;

            _sizeF = Conversion.GetPageSize(_bytes, CurrentPage);

            CurrentPage++;
            if (CurrentPage > _pages - 1)
                CurrentPage = _pages;
        }

        public Image GetImageForRect(int width, int height)
        {
            if (_bytes == null)
                throw new Exception("Нет изображения");

            double kW = width / _sizeF.Width;
            double kH = height / _sizeF.Height;

            var k = Math.Min(kH, kW) * .95;

            var options = new RenderOptions
            {
                Width = (int)(_sizeF.Width * k),
                Height = (int)(_sizeF.Height * k),
            };

            using (var memoryStream = new MemoryStream())
            {
                Conversion.SaveJpeg(memoryStream, _bytes, null, CurrentPage, options);
                return Image.FromStream(memoryStream);
            }
        }
    }
}
