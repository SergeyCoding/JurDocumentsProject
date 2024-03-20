using JurDocsServer.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JurDocsServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetListDocumentsController : ControllerBase
    {
        private readonly SecurityInfoReader _reader;

        public GetListDocumentsController(SecurityInfoReader reader)
        {
            _reader = reader;
        }

        // GET: api/<ValuesController>
        [HttpGet]

        public ActionResult<string[]> Get(string docName)
        {
            var securityInfo = _reader.GetSecurityInfo();

            var docNameInfo = securityInfo!.Catalogs!.Where(x => x.Name == docName).ToArray();

            if (docNameInfo.Length == 1)
            {
                List<string> list = [];

                var files = Directory.GetFiles(docNameInfo.First().Path);
                foreach (var file in files)
                    list.Add(Path.GetFileName(file));

                return Ok(list);
            }

            return BadRequest();
        }

        [HttpGet("getFile")]
        [SwaggerOperation("Получение файла", "Получение файла")]
        public ActionResult<bool> GetFile([SwaggerParameter("Документ", Required = true)][FromQuery] string docName, [SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName, [SwaggerParameter("ID пользователя", Required = true)][FromQuery] int userId)
        {
            var securityInfo = _reader.GetSecurityInfo();

            var docNameInfo = securityInfo!.Catalogs!.Where(x => x.Name == docName).ToArray();

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

        [HttpPost("clearTemp")]
        [SwaggerOperation("Очистить каталог пользователя")]
        public ActionResult<bool> Post([FromBody] ClearTempRequiest clearTemp)
        {
            var securityInfo = _reader.GetSecurityInfo();

            var users = securityInfo!.Users!.Where(x => x.Id == clearTemp.UserId).ToArray();

            if (users.Length != 1)
                return BadRequest();

            var files = Directory.GetFiles(users.First().Path);

            foreach (var item in files)
                System.IO.File.Delete(item);

            return Ok(true);
        }

        public record struct ClearTempRequiest([SwaggerParameter("ID пользователя", Required = true)][FromBody] int UserId);
    }
}
