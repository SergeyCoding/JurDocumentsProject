using DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocsServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentFileController : ControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public DocumentFileController(JurDocsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet()]
        [SwaggerOperation("Получение файла", "Получение файла")]
        public ActionResult<bool> GetFile([SwaggerParameter("Документ", Required = true)][FromQuery] string docName,
                                          [SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName,
                                          [SwaggerParameter("ID пользователя", Required = true)][FromQuery] int userId)
        {

            var loginClaim = User.Claims.FirstOrDefault(x => x.Type == "Login");

            if (loginClaim == null)
                return BadRequest();

            var jurDocUser = _dbContext.Set<JurDocUser>().FirstOrDefault(x => x.Login == loginClaim.Value);

            if (jurDocUser == null)
                return BadRequest();

            var docNameInfo = securityInfo!.Catalogs!.Where(x => x.Name == docName && x.Read.Contains(userId)).ToArray();

            if (docNameInfo.Length != 1)
                return BadRequest();

            List<string> list = [];

            var fileSource = Path.Combine(docNameInfo.First().Path, fileName);

            var users = securityInfo!.Users!.Where(x => x.Id == userId).ToArray();

            if (users.Length != 1)
                return BadRequest();

            var fileDest = Path.Combine(users.First().Path, fileName);

            if (!System.IO.File.Exists(fileSource))
                return BadRequest();


            System.IO.File.Copy(fileSource, fileDest);
            return Ok(true);
        }

        [HttpPost()]
        [SwaggerOperation("Получение файла", "Получение файла")]
        public ActionResult<bool> Post([SwaggerParameter("Документ", Required = true)][FromQuery] string docName,
                                       [SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName,
                                       [SwaggerParameter("ID пользователя", Required = true)][FromQuery] int userId)
        {

            var docNameInfo = securityInfo!.Catalogs!.Where(x => x.Name == docName && x.Read.Contains(userId)).ToArray();

            if (docNameInfo.Length != 1)
                return BadRequest();

            List<string> list = [];

            var fileSource = Path.Combine(docNameInfo.First().Path, fileName);

            var users = securityInfo!.Users!.Where(x => x.Id == userId).ToArray();

            if (users.Length != 1)
                return BadRequest();

            var fileDest = Path.Combine(users.First().Path, fileName);

            if (!System.IO.File.Exists(fileSource))
                return BadRequest();


            System.IO.File.Copy(fileSource, fileDest);
            return Ok(true);
        }
    }
}
