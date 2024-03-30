using DbModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace JurDocsServer.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsAuthHandler : AuthenticationHandler<JurDocsAuthOptions>
    {
        private readonly JurDocsDbContext _dbContext;

        public JurDocsAuthHandler(IOptionsMonitor<JurDocsAuthOptions> options,
                                  ILoggerFactory logger,
                                  UrlEncoder encoder,
                                  JurDocsDbContext dbContext) : base(options, logger, encoder)
        {
            _dbContext = dbContext;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(Options.AuthHeader))
                return AuthenticateResult.Fail($"Missing header: {Options.AuthHeader}");

            string token = Request.Headers[Options.AuthHeader]!;

            var guidToken = new Guid(token);

            var userToken = await _dbContext.Set<Token>().Where(x => x.Value == guidToken).ToArrayAsync();

            if (userToken.Length != 1)
                return AuthenticateResult.Fail($"Invalid token.");

            var user = userToken.First();

            var claims = new List<Claim>() { new Claim("Login", user.Login!), new Claim("Id", user.Id.ToString()) };

            var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
        }
    }

}
