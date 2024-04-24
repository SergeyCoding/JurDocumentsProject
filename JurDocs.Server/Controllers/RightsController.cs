using JurDocs.Common.Loggers;
using JurDocs.DbModel;
using JurDocs.Server.Controllers.Base;
using JurDocs.Server.Model.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JurDocs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RightsController : JurDocsControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public RightsController(JurDocsDbContext dbContext, IConfiguration configuration, ILogger<LogFile> logger)
            : base(configuration, logger)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProjectRights[]), 200)]
        public async Task<IActionResult> Get([FromQuery] int projectId)
        {
            try
            {
                var projectRights = await _dbContext.Set<ProjectRights>()
                    .AsNoTracking()
                    .Where(x => x.ProjectId == projectId)
                    .ToArrayAsync();

                if (projectRights != null)
                    return Ok(projectRights);
            }
            catch (Exception)
            {
            }

            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<string>), 200)]
        [ProducesResponseType(typeof(DataResponse<string>), 400)]
        public async Task<IActionResult> Post([FromBody] RightsPostRequest rights)
        {
            try
            {
                var login = GetUserLogin();

                var owner = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Login == login);

                if (owner == null)
                    return BadRequest(new DataResponse<string> { Status = 400, MessageToUser = "Нет прав для изменения данного проекта" });

                var jurDocProject = _dbContext.Set<JurDocProject>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == rights.ProjectId && x.OwnerId == owner.Id);

                if (jurDocProject == null)
                    return BadRequest(new DataResponse<string> { Status = 400, MessageToUser = "Нет прав для изменения данного проекта" });

                var projectRights = await _dbContext.Set<ProjectRights>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ProjectId == rights.ProjectId && x.UserId == rights.UserId && x.DocType == rights.DocType);

                if (projectRights != null)
                    return Ok(new DataResponse<string> { Status = 200, MessageToUser = string.Empty });

                var newRights = new ProjectRights
                {
                    ProjectId = rights.ProjectId,
                    DocType = rights.DocType,
                    UserId = rights.UserId,
                };

                await _dbContext.AddAsync(newRights).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                return Ok(new DataResponse<string> { Status = 200, MessageToUser = string.Empty });
            }
            catch (Exception e)
            {
                _logger?.LogError(e, null);
                return BadRequest(new DataResponse<string>
                {
                    Status = 400,
                    Data = null,
                    Errors = [e.ToString()],
                    MessageToUser = "Непредвиденная ошибка"
                });
            }

        }

        public record class RightsPostRequest
        {
            public int ProjectId { get; set; }
            public string? DocType { get; set; }
            public int UserId { get; set; }
        }


        [HttpDelete]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Delete([FromBody] ProjectRights rights)
        {
            try
            {
                var login = GetUserLogin();

                var owner = await _dbContext.Set<JurDocUser>().FirstOrDefaultAsync(x => x.Login == login);

                if (owner == null)
                    return BadRequest("Нет прав для изменения данного проекта");

                var jurDocProject = _dbContext.Set<JurDocProject>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == rights.ProjectId && x.OwnerId == owner.Id);

                if (jurDocProject == null)
                    return BadRequest("Нет прав для изменения данного проекта");

                var projectRights = await _dbContext.Set<ProjectRights>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ProjectId == rights.ProjectId && x.UserId == rights.UserId && x.DocType == rights.DocType);

                if (projectRights != null)
                    return Ok("OK");

                var newRights = new ProjectRights
                {
                    ProjectId = rights.ProjectId,
                    DocType = rights.DocType,
                    UserId = rights.UserId,
                };

                return Ok("OK");
            }
            catch (Exception)
            {
            }

            return BadRequest();
        }
    }
}
