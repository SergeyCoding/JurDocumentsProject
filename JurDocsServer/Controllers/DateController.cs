using JurDocs.Common.Loggers;
using Microsoft.AspNetCore.Mvc;

namespace JurDocs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateController : ControllerBase
    {
        private readonly ILogger<LogFile>? _logFile;

        public DateController(ILogger<LogFile>? logFile)
        {
            _logFile = logFile;
        }

        [HttpGet]
        public ActionResult<DateTime> Get()
        {
            var utcNow = DateTime.UtcNow;

            _logFile?.LogInformation("{msg}", $"Date: {utcNow}");

            return base.Ok(utcNow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        [Route("Delay")]
        [HttpGet]
        public async Task<ActionResult<DateTime>> GetDelay(int delay = 1000)
        {
            await Task.Delay(delay);

            return Ok(delay);
        }
    }
}
