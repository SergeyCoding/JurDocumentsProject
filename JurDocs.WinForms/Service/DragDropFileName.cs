namespace JurDocs.WinForms.Service
{
    /// <summary>
    /// 
    /// </summary>
    internal class DragDropFileName(IDataObject? data)
    {
        private readonly IDataObject? _data = data;

        public string FileName { get; private set; } = string.Empty;
        public bool IsOk { get; private set; } = false;

        public void Execute()
        {

            if (_data == null)
            {
                IsOk = false;
                return;
            }

            if (_data.GetData("FileDrop") is Array data)
            {
                if (data.Length == 1 && data.GetValue(0) is string)
                {
                    FileName = ((string[])data)[0];
                    string ext = Path.GetExtension(FileName).ToLower();

                    string[] extList = [".jpg", ".png", ".bmp", ".pdf"];

                    if (extList.Any(x => x == ext))
                        IsOk = true;
                }
            }
        }
    }
}