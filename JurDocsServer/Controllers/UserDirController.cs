using DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocsServer.Controllers
{
    /// <summary>
    /// Работа с директорией пользователя
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserDirController : ControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public UserDirController(JurDocsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost()]
        [SwaggerOperation("Очистить каталог пользователя", Tags = ["Директория пользователей"])]
        public ActionResult<ClearTempResponse> Post([FromBody] ClearTempRequiest clearTemp)
        {

            var users = securityInfo!.Users!.Where(x => x.Id == clearTemp.UserId).ToArray();

            if (users.Length != 1)
                return BadRequest();

            var files = Directory.GetFiles(users.First().Path);

            foreach (var item in files)
                System.IO.File.Delete(item);

            return Ok(new ClearTempResponse(true));
        }

        public record struct ClearTempRequiest([SwaggerParameter("ID пользователя", Required = true)][FromBody] int UserId);
        public record struct ClearTempResponse([SwaggerParameter("Результат работы операции", Required = true)] bool Result);
    }
}
