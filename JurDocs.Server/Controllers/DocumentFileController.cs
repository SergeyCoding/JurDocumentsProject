using JurDocs.Common.Loggers;
using JurDocs.DbModel;
using JurDocs.Server.Controllers.Base;
using JurDocs.Server.Model.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using SysFile = System.IO.File;

namespace JurDocs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentFileController : JurDocsControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public DocumentFileController(JurDocsDbContext dbContext, IConfiguration configuration, ILogger<LogFile> logger)
            : base(configuration, logger)
        {
            _dbContext = dbContext;
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
            var userLogin = GetUserLogin();

            if (!await AllowDocumentAsync(projectName, docType, userLogin))
            {
                _logger.LogInformation("{msg}", "Нет доступа к документу");
                return Forbid("Нет доступа к документу");
            }

            var fn = Path.GetFileName(fileName);

            var fileSource = Path.Combine(Settings!.Catalog!, projectName, docType, fn);

            var jurDocUser = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Login == userLogin);

            if (jurDocUser == null)
                return BadRequest();

            var fileDest = Path.Combine(jurDocUser.Path!, projectName, docType, fn);

            if (!SysFile.Exists(fileSource))
                return BadRequest();


            SysFile.Copy(fileSource, fileDest);
            return Ok(true);
        }

        [HttpGet("local-filename")]
        [SwaggerOperation("Получение имени локального файла", "Получение имени локального файла")]
        [ProducesResponseType(typeof(DataResponse<string>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 401)]
        [ProducesResponseType(typeof(string), 403)]
        public async Task<IActionResult> GetLocalFileName(
            [SwaggerParameter("Проект", Required = true)][FromQuery] string projectName,
            [SwaggerParameter("Документ", Required = true)][FromQuery] string docType,
            [SwaggerParameter("ID документа", Required = true)][FromQuery] int docId)
        {
            var userLogin = GetUserLogin();

            if (!await AllowDocumentAsync(projectName, docType, userLogin))
            {
                _logger.LogInformation("{msg}", "Нет доступа к документу");
                return Forbid("Нет доступа к документу");
            }

            var jurDocUser = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Login == userLogin);

            if (jurDocUser == null)
                return BadRequest();

            var localFileName = Path.Combine(
                jurDocUser.Path!,
                projectName,
                docType,
                $"{projectName}_{docType}_{docId}.pdf");

            return Ok(new DataResponse<string>(localFileName));
        }


        /// <summary>
        /// Проверка доступа пользователя к документу по проекту и типу документа
        /// </summary>
        private async Task<bool> AllowDocumentAsync(string projectName, string docType, string login)
        {
            var jurDocUser = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Login == login);

            if (jurDocUser == null)
                return false;

            var project = await _dbContext.Set<JurDocProject>().FirstOrDefaultAsync(x => x.Name == projectName);

            if (project == null)
                return false;

            if (project.OwnerId == jurDocUser.Id)
                return true;

            var allow = await _dbContext.Set<ProjectRights>().AnyAsync(x => x.UserId == jurDocUser.Id && docType == x.DocType && x.ProjectId == project.Id);

            return allow;
        }

        [HttpPost()]
        [SwaggerOperation("Сохранение файла", "Сохранение файла")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 401)]
        [ProducesResponseType(typeof(string), 403)]
        public async Task<IActionResult> Post([SwaggerParameter("Проект", Required = true)][FromQuery] string projectName,
                                        [SwaggerParameter("Документ", Required = true)][FromQuery] string docType,
                                        [SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName)
        {
            try
            {
                var userLogin = GetUserLogin();

                if (!await AllowDocumentAsync(projectName, docType, userLogin))
                {
                    return Forbid("Нет доступа к документу");
                }

                if (!SysFile.Exists(fileName))
                {
                    return BadRequest("Файл не найден");
                }

                var fn = Path.GetFileName(fileName);

                var fileDest = Path.Combine(Settings!.Catalog!, projectName, docType, fn);

                if (!Directory.Exists(Path.GetDirectoryName(fileDest)))
                    Directory.CreateDirectory(Path.GetDirectoryName(fileDest)!);

                SysFile.Copy(fileName, fileDest, true);

                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete()]
        [SwaggerOperation("Удаление файл во временном каталоге", "Удаление файл во временном каталоге")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 401)]
        [ProducesResponseType(typeof(string), 403)]
        public async Task<IActionResult> Delete([SwaggerParameter("Имя файла", Required = true)][FromQuery] string fileName)
        {
            try
            {
                _logger.LogInformation("Удаление файла");

                var userLogin = GetUserLogin();

                var jurDocUser = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Login == userLogin);

                if (jurDocUser == null)
                {
                    _logger?.LogInformation("Пользователь {user} не найден", userLogin);
                    return BadRequest();
                }

                var curFile = Path.Combine(Settings!.Catalog!, jurDocUser.Path!, fileName);

                if (SysFile.Exists(curFile))
                    SysFile.Delete(curFile);

                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }


}
