using Microsoft.AspNetCore.Authentication;

namespace JurDocs.Server.Service
{
    public class JurDocsAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "JurDocsAuthScheme";
        public string AuthHeader { get; set; } = "Authorization";
    }
}
