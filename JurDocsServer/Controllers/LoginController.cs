using DbModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        //[SwaggerOperation()]
        public async Task<IActionResult> Get(string Login)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();

                var guidToken = new Guid(token);

                var userToken = await _dbContext.Set<Token>().Where(x => x.Login == Login && x.Value == guidToken).ToArrayAsync();

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


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400, Type = typeof(LoginErrorResponse))]
        public async Task<IActionResult> Post([FromBody] LoginPostRequest loginRequest)
        {
            try
            {
                var jurDocUser = await _dbContext.Set<JurDocUser>().Where(x => x.Login == loginRequest.Login && x.Password == loginRequest.Password).ToArrayAsync();

                if (jurDocUser.Length == 1)
                {
                    var guid = Guid.NewGuid();

                    _dbContext.Set<Token>().Add(new Token { Login = loginRequest.Login, Value = guid });

                    return Ok(guid);
                }
                else
                {
                    return BadRequest(new LoginErrorResponse { Status = 400, Descr = "Неверный логин или пароль" });

                }
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.ToString());
            }

            return BadRequest(new LoginErrorResponse { Status = 400, Descr = "ошибка" });
        }
        public record struct LoginPostRequest(string Login, string Password);
        public record struct LoginPostResponse(Guid Token);
        public record struct LoginErrorResponse(int Status, string Descr);

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();

                var guidToken = new Guid(token);

                var userToken = await _dbContext.Set<Token>().Where(x => x.Value == guidToken).ToArrayAsync();

                if (userToken.Any())
                    _dbContext.Set<Token>().RemoveRange(userToken);
            }
            catch (Exception)
            {
            }

            return Ok();
        }
    }
}
