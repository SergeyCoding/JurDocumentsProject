using Microsoft.AspNetCore.Mvc;

namespace LexDisposition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateController : ControllerBase
    {
        [HttpGet]
        public ActionResult<DateTime> Get()
        {
            return Ok(DateTime.UtcNow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        [Route("Delay")]
        [HttpGet]
        public async Task<ActionResult<DateTime>> GetDelay(int delay=1000)
        {
            await Task.Delay(delay);

            return Ok(delay);
        }
    }
}
