using JurDocs.Common.Loggers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [ProducesResponseType(typeof(DateResp), 200)]
        public IActionResult Get()
        {
            var date = DateTime.UtcNow;

            _logFile?.LogInformation("{msg}", $"Date: {date}");

            return base.Ok(new DateResp(date));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        [Route("Delay")]
        [HttpGet]
        [ProducesResponseType(typeof(DelayResp), 200)]
        public async Task<IActionResult> GetDelay(int delay = 1000)
        {
            _logFile?.LogInformation("{msg}", delay);

            await Task.Delay(delay);

            return Ok(new DelayResp(delay));
        }
    }

    internal record DateResp([property: SwaggerSchema(Format = "date-time")] DateTime Date);

    internal record DelayResp(int Delay);
}
