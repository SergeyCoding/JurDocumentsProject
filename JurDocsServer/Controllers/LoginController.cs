using DbModel;
using JurDocsServer.Model;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        //[SwaggerOperation()]
        public async Task<IActionResult> Get(string Login)
        {
            try
            {
                if (User.Identity!.IsAuthenticated)
                {
                    var claims = User.Claims.ToArray();

                    var loginClaim = claims.FirstOrDefault(x => x.Type == "Login");
                    var idClaim = claims.FirstOrDefault(x => x.Type == "Id");

                    var id = int.Parse(idClaim!.Value);
                    var login = loginClaim!.Value;

                    if (Login != login)
                        return BadRequest();

                    var user = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Id == id && x.Login == login);

                    if (user != null)
                        return base.Ok(new LoginGetResponse(user.Id, user.Name!, user.Path!));
                }
            }
            catch (Exception)
            {
            }

            return BadRequest();
        }

        public record struct LoginGetResponse(int Id, string Name, string Path);


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

                    var tokens = await _dbContext.Set<Token>().Where(x => x.Login == loginRequest.Login).ToArrayAsync();
                    _dbContext.RemoveRange(tokens);
                    _dbContext.SaveChanges();

                    _dbContext.Set<Token>().Add(new Token { Login = loginRequest.Login, Value = guid });
                    _dbContext.SaveChanges(true);

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
        [Authorize]
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
