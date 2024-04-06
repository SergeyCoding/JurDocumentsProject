using DbModel;
using JurDocs.Common.Loggers;
using JurDocsServer.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILogger<LogFile> _logger;
        private JurDocsApp? _settings;

        public DocumentFileController(JurDocsDbContext dbContext, IConfiguration configuration, ILogger<LogFile> logger)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet()]
        [SwaggerOperation("Получение файла", "Получение файла")]

        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 401)]
        [ProducesResponseType(typeof(string), 403)]
        public async Task<IActionResult> GetFile([SwaggerParameter("Проект", Required = true)][FromQuery] string projectName,
                                          [SwaggerParameter("Документ", Required = true)][FromQuery] string docType,
                                          [SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName)
        {
            _settings = null;
            _configuration.GetSection(JurDocsApp.sectionName).Bind(_settings);

            if (_settings == null)
                return BadRequest();

            _settings.Validate();

            var userLogin = User.Claims.FirstOrDefault(x => x.Type == "Login");

            if (!await AllowDocumentAsync(projectName, docType, userLogin!.Value))
            {
                return Forbid("Нет доступа к документу");
            }

            var fileSource = Path.Combine(_settings.Catalog!, projectName, docType, fileName);

            var jurDocUser = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Login == userLogin!.Value);

            if (jurDocUser == null)
                return BadRequest();

            var fileDest = Path.Combine(_settings.Catalog!, jurDocUser.Path!, fileName);

            if (!System.IO.File.Exists(fileSource))
                return BadRequest();


            System.IO.File.Copy(fileSource, fileDest);
            return Ok(true);
        }

        /// <summary>
        /// Проверка доступа пользователя к документу по проекту и типу документа
        /// </summary>
        private async Task<bool> AllowDocumentAsync(string projectName, string docType, string login)
        {
            var jurDocUser = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Login == login);

            if (jurDocUser == null)
                return false;

            var project = await _dbContext.Set<Project>().FirstOrDefaultAsync(x => x.Name == projectName);

            if (project == null)
                return false;

            if (project.OwnerId == jurDocUser.Id)
                return true;

            var allow = await _dbContext.Set<ProjectRights>().AnyAsync(x => x.UserId == jurDocUser.Id && docType == x.DocType && x.ProjectId == project.Id);

            return allow;
        }

        [HttpPost()]
        [SwaggerOperation("Получение файла", "Получение файла")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 401)]
        [ProducesResponseType(typeof(string), 403)]
        public async Task<IActionResult> Post([SwaggerParameter("Проект", Required = true)][FromQuery] string projectName,
                                        [SwaggerParameter("Документ", Required = true)][FromQuery] string docType,
                                        [SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName)
        {

            _settings = null;
            _configuration.GetSection(JurDocsApp.sectionName).Bind(_settings);

            if (_settings == null)
                return BadRequest();

            _settings.Validate();

            var userLogin = User.Claims.FirstOrDefault(x => x.Type == "Login");

            if (!await AllowDocumentAsync(projectName, docType, userLogin!.Value))
            {
                return Forbid("Нет доступа к документу");
            }


            var fileSource = Path.Combine(_settings.Catalog!, projectName, docType, fileName);

            var jurDocUser = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Login == userLogin!.Value);

            if (jurDocUser == null)
                return BadRequest();

            var fileDest = Path.Combine(_settings.Catalog!, jurDocUser.Path!, fileName);

            if (!System.IO.File.Exists(fileSource))
                return BadRequest();


            System.IO.File.Copy(fileDest, fileSource);
            return Ok(true);
        }
    }
}
