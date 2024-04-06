namespace JurDocs.Server.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsApp
    {
        public const string sectionName = "JurDocsApp";

        public string? Catalog { get; set; }
        public string? LogDir { get; set; }

        internal void Validate()
        {
            if (string.IsNullOrWhiteSpace(Catalog))
                throw new Exception("Не заполнен Catalog в конфигурационном файле");
        }
    }


}
