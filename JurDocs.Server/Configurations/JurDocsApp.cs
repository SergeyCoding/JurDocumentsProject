namespace JurDocs.Server.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsApp
    {
        public const string sectionName = "JurDocsApp";

        public string? AdditionalConfig { get; set; }
        public string? Catalog { get; set; }
        public string? LogDir { get; set; }
        public string? RootToken { get; set; }
        public Guid GuidRootToken
        {
            get
            {
                if (Guid.TryParse(RootToken, out Guid result))
                    return result;

                return Guid.Empty;
            }
        }

        internal void Validate()
        {
            if (string.IsNullOrWhiteSpace(Catalog))
                throw new Exception("Не заполнен Catalog в конфигурационном файле");

            if (GuidRootToken == Guid.Empty)
                throw new Exception("Неверно заполнен RootToken в конфигурационном файле");
        }
    }


}
