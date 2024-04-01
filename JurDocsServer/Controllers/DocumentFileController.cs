using DbModel;
using JurDocsServer.Configurations;
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
        private readonly IConfiguration _configuration;
        private JurDocsApp _settings;

        public DocumentFileController(JurDocsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet()]
        [SwaggerOperation("Получение файла", "Получение файла")]
        public ActionResult<bool> GetFile([SwaggerParameter("Проект", Required = true)][FromQuery] string projectName,
                                          [SwaggerParameter("Документ", Required = true)][FromQuery] string docType,
                                          [SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName)
        {

            _configuration.GetSection(JurDocsApp.sectionName).Bind(_settings);
            _settings.Validate();

            var loginClaim = User.Claims.FirstOrDefault(x => x.Type == "Login");

            if (loginClaim == null)
                return BadRequest();

            var jurDocUser = _dbContext.Set<JurDocUser>().FirstOrDefault(x => x.Login == loginClaim.Value);

            if (jurDocUser == null)
                return BadRequest();




            var docNameInfo = securityInfo!.Catalogs!.Where(x => x.Name == docType && x.Read.Contains(userId)).ToArray();

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
        public ActionResult<bool> Post([SwaggerParameter("Проект", Required = true)][FromQuery] string projectName,
                                       [SwaggerParameter("Документ", Required = true)][FromQuery] string docName,
                                       [SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName)
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
