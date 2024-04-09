namespace JurDocs.WinForms.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsApp
    {
        public const string sectionName = "JurDocsApp";

        public string? UrlBase { get; set; }
        public string? LogDir { get; set; }



        internal void Validate()
        {
            if (string.IsNullOrWhiteSpace(UrlBase))
                throw new Exception("Не заполнен UrlBase в конфигурационном файле");

            if (string.IsNullOrWhiteSpace(LogDir))
                throw new Exception("Не заполнен LogDir в конфигурационном файле");
        }
    }
}
