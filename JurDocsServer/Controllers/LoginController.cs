using DbModel;
using JurDocs.Common.Loggers;
using JurDocs.DbModel;
using JurDocs.Server.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocs.Server.Controllers
{
    /// <summary>
    /// Логин 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class LoginController : JurDocsControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public LoginController(JurDocsDbContext dbContext, IConfiguration configuration, ILogger<LogFile> logger)
            : base(configuration, logger)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation("Сведения о пользователе", "Сведения о пользователе")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(LoginGetResponse), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Get(string Login)
        {
            try
            {
                var login = GetUserLogin();

                if (login != Login)
                    return BadRequest("Неверно указан логин");

                var user = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Login == login);

                if (user != null)
                    return base.Ok(new LoginGetResponse(user.Id, user.Name!, user.Path!));
            }
            catch (Exception e)
            {
                _logger.LogError(e, null);
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
                var jurDocUser = await _dbContext.Set<JurDocUser>()
                                                 .Where(x => x.Login == loginRequest.Login && x.Password == loginRequest.Password)
                                                 .ToArrayAsync();

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
