using Microsoft.AspNetCore.Authentication;

namespace JurDocsServer.Service
{
    public class JurDocsAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "JurDocsAuthScheme";
        public string AuthHeader { get; set; } = "Authorization";
    }
}
