using JurDocsServer.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocsServer.Controllers
{
    /// <summary>
    /// Работа с директорией пользователя
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserDirController : ControllerBase
    {
        private readonly SecurityInfoReader _reader;

        public UserDirController(SecurityInfoReader reader)
        {
            _reader = reader;
        }

        [HttpPost()]
        [SwaggerOperation("Очистить каталог пользователя")]
        public ActionResult<ClearTempResponse> Post([FromBody] ClearTempRequiest clearTemp)
        {
            var securityInfo = _reader.GetSecurityInfo();

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
