using JurDocs.DbModel;
using JurDocs.Server.Configurations;
using JurDocs.Server.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace JurDocs.Server.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsAuthHandler : AuthenticationHandler<JurDocsAuthOptions>
    {
        private readonly JurDocsDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public JurDocsAuthHandler(IOptionsMonitor<JurDocsAuthOptions> options,
                                  ILoggerFactory logger,
                                  UrlEncoder encoder,
                                  JurDocsDbContext dbContext, IConfiguration configuration) : base(options, logger, encoder)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            if (!Request.Headers.TryGetValue(Options.AuthHeader, out var value))
                return AuthenticateResult.Fail($"Missing header: {Options.AuthHeader}");

            string token = value!;

            if (!Guid.TryParse(token, out var guidToken))
                return AuthenticateResult.Fail($"Invalid token.");

            var _adminToken = _configuration.GetRequiredSection(JurDocsApp.sectionName).Get<JurDocsApp>();
            if (guidToken == _adminToken?.GuidRootToken)
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
