using JurDocs.Common.Loggers;
using JurDocs.DbModel;
using JurDocs.Server.Controllers.Base;
using JurDocs.Server.Model.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics.Metrics;

namespace JurDocs.Server.Controllers1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LetterDocumentController : JurDocsControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public LetterDocumentController(JurDocsDbContext dbContext, IConfiguration configuration, ILogger<LogFile> logger)
            : base(configuration, logger)
        {
            _dbContext = dbContext;
        }

        [SwaggerOperation("Получить список писем")]
        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<JurDocLetter[]>), 200)]
        [ProducesResponseType(typeof(DataResponse<JurDocLetter[]>), 400)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var user = await GetCurrentUser();

                var pIdList = await GetAvailableProjectIdList(user.Id);

                var letters = await _dbContext.Set<JurDocLetter>()
                                .AsNoTracking()
                                .Where(x => pIdList.Contains(x.ProjectId))
                                .ToArrayAsync();

                return Ok(new DataResponse<JurDocLetter[]>(letters));
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return Ok();
            }
        }

        private async Task<JurDocUser> GetCurrentUser()
        {
            var login = GetUserLogin();
            return await _dbContext.Set<JurDocUser>().FirstAsync(x => x.Login == login);
        }

        private async Task<int[]> GetAvailableProjectIdList(int userId)
        {
            var projectRights = await _dbContext.Set<ProjectRights>()
                .AsNoTracking()
                .Where(x => x.DocType == "Справка")
                .Where(x => x.UserId == userId)
                .Select(x => x.Id)
                .Distinct()
                .ToArrayAsync();

            var availableProjectList = await _dbContext.Set<JurDocProject>()
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Where(x => x.OwnerId == userId || projectRights.Contains(x.Id))
                .Select(x => x.Id)
                .Distinct()
                .ToArrayAsync();

            return availableProjectList;
        }

        [SwaggerOperation("Получить письмо по Id проекта")]
        [HttpGet("{projectId}")]
        [ProducesResponseType(typeof(DataResponse<JurDocLetter[]>), 200)]
        [ProducesResponseType(typeof(DataResponse<JurDocLetter[]>), 400)]
        public async Task<IActionResult> Get(int projectId)
        {
            try
            {
                var login = GetUserLogin();

                var user = await _dbContext.Set<JurDocUser>().FirstAsync(x => x.Login == login);

                var project = await _dbContext.Set<JurDocProject>()
                    .AsNoTracking()
                    .Where(x => x.Id == projectId)
                    .Where(x => x.OwnerId == user!.Id)
                    .ToArrayAsync();

                if (project.Any())
                    return Ok(new DataResponse<JurDocProject>(project.First()));

                var projectRights = await _dbContext.Set<ProjectRights>()
                    .AsNoTracking()
                    .Where(x => x.ProjectId == projectId)
                    .Where(x => x.UserId == user!.Id)
                    .Select(x => x.Id)
                    .Take(1)
                    .ToArrayAsync();

                if (projectRights.Any())
                {
                    var projectByOwners = await _dbContext.Set<JurDocProject>()
                        .AsNoTracking()
                        .Where(x => (x.OwnerId == user!.Id || projectRights.Contains(x.Id)) && !x.IsDeleted)
                        .ToArrayAsync();

                    return Ok(new DataResponse<JurDocProject>(projectByOwners[0]));
                }

                return Ok(new DataResponse<JurDocProject>(StatusDataResponse.BAD, "Нет прав для использования данного проекта"));
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return Ok(new DataResponse<JurDocProject>(StatusDataResponse.BAD)
                {
                    Errors = [e.ToString()],
                    MessageToUser = "Нет прав для использования данного проекта"
                });
            }
        }


        [HttpPost]
        [SwaggerOperation("Создать письмо", "Создать письмо")]
        [ProducesResponseType(typeof(DataResponse<JurDocLetter>), 200)]
        [ProducesResponseType(typeof(DataResponse<JurDocLetter>), 400)]
        public async Task<IActionResult> Post(int projectId)
        {
            try
            {
                var user = await GetCurrentUser();

                var pIdList = await GetAvailableProjectIdList(user.Id);

                if (!pIdList.Contains(projectId))
                    return Ok(new DataResponse<JurDocLetter>(StatusDataResponse.BAD, "Недосточно прав для создания письма в текущем проекте"));

                var letter = new JurDocLetter { ProjectId = projectId };

                var newLetter = await _dbContext.AddAsync(letter);
                await _dbContext.SaveChangesAsync();

                return Ok(new DataResponse<JurDocLetter>(letter));
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest(new DataResponse<JurDocLetter>(StatusDataResponse.BAD, "Непредвиденная ошибка") { Errors = [e.ToString()] });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(DataResponse<JurDocLetter>), 200)]
        [ProducesResponseType(typeof(DataResponse<JurDocLetter>), 400)]
        public async Task<IActionResult> Put([FromBody] JurDocLetter letter)
        {
            try
            {
                var docUser = await GetCurrentUser();
                var pIdList = await GetAvailableProjectIdList(docUser.Id);

                if (!pIdList.Contains(letter.ProjectId))
                    return BadRequest(new DataResponse<JurDocLetter>(StatusDataResponse.BAD, "Нет прав для изменения данного письма"));


                var oldLetter = await _dbContext.Set<JurDocLetter>().FirstAsync(x => x.Id == letter.Id);

                oldLetter.Name = letter.Name;
                oldLetter.ExecutivePerson = letter.ExecutivePerson;
                oldLetter.NumberOutgoing = letter.NumberOutgoing;
                oldLetter.NumberIncoming = letter.NumberIncoming;
                oldLetter.DateOutgoing = letter.DateOutgoing;
                oldLetter.DateIncoming = letter.DateIncoming;

                oldLetter.Attributes.Clear();
                oldLetter.Attributes.AddRange(letter.Attributes);

                await _dbContext.SaveChangesAsync();

                return Ok(new DataResponse<JurDocLetter>(oldLetter));
            }
            catch (DbUpdateException e)
            {
                _logger?.LogError(e, message: null);
                return BadRequest(new DataResponse<JurDocProject>(StatusDataResponse.BAD, "Ошибка при обновлении письма"));
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest(new DataResponse<JurDocProject>(StatusDataResponse.BAD)
                {
                    Errors = [e.ToString()]
                });
            }
        }

        [HttpDelete]
        [SwaggerOperation("Удалить письмо", "Удалить письмо")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> Delete([FromBody] int projectId)
        {
            try
            {
                var login = GetUserLogin();

                var user = await _dbContext.Set<JurDocUser>()
                    .AsNoTracking()
                    .FirstAsync(x => x.Login == login);

                var jdProject = await _dbContext.Set<JurDocProject>()
                    .AsTracking()
                    .FirstOrDefaultAsync(x => x.Id == projectId && x.OwnerId == user.Id);


                if (jdProject == null)
                    return Ok();

                jdProject.IsDeleted = true;
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);
                return BadRequest();
            }
        }
    }
}
