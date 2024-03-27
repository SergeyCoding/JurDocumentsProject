using JurDocsClient;

namespace JurDocsWinForms.Model
{
    /// <summary>
    /// Операции с новым документом
    /// </summary>
    internal class FileNewDoc
    {
        private readonly string _fileName;
        private readonly string _tempDir;

        public FileNewDoc(string fileName, string tempDir)
        {
            _fileName = fileName;
            _tempDir = tempDir;
        }

        public void SendToServer()
        {
            var tempFileName = Path.Combine(_tempDir, Path.GetFileName(_fileName));

            File.Copy(_fileName, tempFileName, true);

            var client = JurClientService.JurDocsClientFactory();

            if (client != null )
            {
                //client.s
            }
        }
    }
}
