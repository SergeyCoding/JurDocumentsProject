using DbModel;
using JurDocs.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocs.Server.Controllers
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
        [ProducesResponseType(typeof(ClearTempResponse), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 401)]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IActionResult> Post()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {


                var idClaim = User.Claims.FirstOrDefault(x => x.Type == "Id");

                var users = _dbContext.Set<JurDocUser>().First(x => x.Id.ToString() == idClaim!.Value);

                var files = Directory.GetFiles(users.Path!);

                foreach (var item in files)
                    System.IO.File.Delete(item);

                return Ok(new ClearTempResponse(true));
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        public record struct ClearTempResponse([SwaggerParameter("Результат работы операции", Required = true)] bool Result);
    }
}
