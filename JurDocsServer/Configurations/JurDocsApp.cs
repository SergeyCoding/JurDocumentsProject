
namespace JurDocsServer.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsApp
    {
        public const string sectionName = "Lex";

        public string? Catalog { get; set; }

        internal void Validate()
        {
            if (Catalog != null)
            {
                throw new Exception();
            }
        }
    }


}
