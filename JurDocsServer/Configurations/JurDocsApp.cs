
namespace JurDocsServer.Configurations
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
            if (Catalog != null)
            {
                throw new Exception();
            }
        }
    }


}
