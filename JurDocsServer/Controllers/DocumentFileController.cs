using JurDocsServer.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocsServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentFileController : ControllerBase
    {
        private readonly SecurityInfoReader _reader;

        public DocumentFileController(SecurityInfoReader reader)
        {
            _reader = reader;
        }

        [HttpGet()]
        [SwaggerOperation("Получение файла", "Получение файла")]
        public ActionResult<bool> GetFile([SwaggerParameter("Документ", Required = true)][FromQuery] string docName, [SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName, [SwaggerParameter("ID пользователя", Required = true)][FromQuery] int userId)
        {
            var securityInfo = _reader.GetSecurityInfo();

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
        public ActionResult<bool> Post([SwaggerParameter("Документ", Required = true)][FromQuery] string docName, [SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName, [SwaggerParameter("ID пользователя", Required = true)][FromQuery] int userId)
        {
            var securityInfo = _reader.GetSecurityInfo();

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
