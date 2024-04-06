using JurDocs.Common.Loggers;
using JurDocs.Server.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace JurDocs.Server.Controllers.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class JurDocsControllerBase : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        protected readonly ILogger<LogFile> _logger;
        protected JurDocsApp? _settings;

        public JurDocsControllerBase(IConfiguration configuration, ILogger<LogFile> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected string GetUserLogin()
        {
            var claim = User.Claims.FirstOrDefault(x => x.Type == "Login");
            return claim!.Value;
        }

        private void InitSettings()
        {
            _settings = _configuration.GetSection(JurDocsApp.sectionName).Get<JurDocsApp>();
            _settings!.Validate();
        }
    }
}
