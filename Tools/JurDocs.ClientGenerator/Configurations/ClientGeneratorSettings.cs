namespace JurDocs.ClientGenerator.Configurations
{
    internal class ClientGeneratorSettings
    {
        public const string sectionName = "ClientGenerator";

        public string? AdditionalConfig { get; set; }
        public string? JurDocsYamlDoc { get; set; }
        public string? JurDocsClientCodefile { get; set; }

        public bool Validate()
        {
            //if (AdditionalConfig != null)
            //    return false;



            return true;
        }
    }
}
