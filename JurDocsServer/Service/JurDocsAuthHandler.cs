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

        private readonly Guid _adminToken = new Guid("bdee5a3d-2962-4013-b6c5-950ad708f6d6");

        public JurDocsAuthHandler(IOptionsMonitor<JurDocsAuthOptions> options,
                                  ILoggerFactory logger,
                                  UrlEncoder encoder,
                                  JurDocsDbContext dbContext) : base(options, logger, encoder)
        {
            _dbContext = dbContext;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(Options.AuthHeader, out var value))
                return AuthenticateResult.Fail($"Missing header: {Options.AuthHeader}");

            string token = value!;

            if (!Guid.TryParse(token, out var guidToken))
                return AuthenticateResult.Fail($"Invalid token.");

            if (guidToken == _adminToken)
                return AdminAuth();

            var userToken = await _dbContext.Set<Token>().Where(x => x.Value == guidToken).ToArrayAsync();

            if (userToken.Length != 1)
                return AuthenticateResult.Fail($"Invalid token.");

            var user = userToken.First();

            var claims = new List<Claim>() {
                new Claim("Login", user.Login!),
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login!)
            };

            var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
        }

        private AuthenticateResult AdminAuth()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Role, "Admin") };

            var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
        }
    }

}
