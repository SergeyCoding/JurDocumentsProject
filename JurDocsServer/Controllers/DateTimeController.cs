using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexScanServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeController : ControllerBase
    {
        // GET: api/<DateTimeController>
        [HttpGet]
        public ActionResult<CurrentDateResponse> Get()
        {
            return new CurrentDateResponse(DateTime.Today);
        }

        // GET api/<DateTimeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value" + id;
        }

        // POST api/<DateTimeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DateTimeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DateTimeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public record struct CurrentDateResponse(DateTime CurrentDate);
    }
}
