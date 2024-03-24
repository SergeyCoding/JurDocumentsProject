using DbModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JurDocsServer.Controllers
{
    /// <summary>
    /// Логин 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public LoginController(JurDocsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        [SwaggerOperation()]
        public async Task<IActionResult> Get(string Login)
        {
            try
            {
                var token = Request.Headers[Request.Headers.Authorization!];

                var userToken = await _dbContext.Set<Token>().Where(x => x.Login == Login && x.Value == new Guid(token.ToString())).ToArrayAsync();

                if (userToken.Length == 1)
                {
                    return Ok(userToken.First().Id);

                }
            }
            catch (Exception)
            {
            }

            return BadRequest();
        }

        public record struct LoginGetResponse(int Id, string Name);

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
