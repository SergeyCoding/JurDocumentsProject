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
        private JurDocsApp? _settings;

        public JurDocsControllerBase(IConfiguration configuration, ILogger<LogFile> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected JurDocsApp Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = _configuration.GetSection(JurDocsApp.sectionName).Get<JurDocsApp>();
                    _settings!.Validate();
                }

                return _settings;
            }
        }

        protected string GetUserLogin()
        {
            var claim = User.Claims.FirstOrDefault(x => x.Type == "Login");
            return claim!.Value;
        }

    }
}
