using JurDocs.Common.Loggers;
using JurDocs.DbModel;
using JurDocs.Server.Controllers.Base;
using JurDocs.Server.Model.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : JurDocsControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public ProjectController(JurDocsDbContext dbContext, IConfiguration configuration, ILogger<LogFile> logger)
            : base(configuration, logger)
        {
            _dbContext = dbContext;
        }

        [SwaggerOperation("Получить список проектов")]
        [HttpGet]
        [ProducesResponseType(typeof(JurDocProject[]), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var login = GetUserLogin();

                var user = await _dbContext.Set<JurDocUser>().FirstAsync(x => x.Login == login);

                var projectRights = await _dbContext.Set<ProjectRights>()
                    .AsNoTracking()
                    .Where(x => x.UserId == user!.Id)
                    .Select(x => x.Id)
                    .Distinct()
                    .ToArrayAsync();

                var projectByOwners = await _dbContext.Set<JurDocProject>()
                    .AsNoTracking()
                    .Where(x => (x.OwnerId == user!.Id || projectRights.Contains(x.Id)) && !x.IsDeleted)
                    .ToArrayAsync();

                return Ok(projectByOwners);
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest();
            }
        }

        [SwaggerOperation("Получить проект по Id")]
        [HttpGet("{projectId}")]
        [ProducesResponseType(typeof(DataResponse<JurDocProject>), 200)]
        [ProducesResponseType(typeof(DataResponse<JurDocProject>), 400)]
        public async Task<IActionResult> Get(int projectId)
        {
            try
            {
                var login = GetUserLogin();

                var user = await _dbContext.Set<JurDocUser>().FirstAsync(x => x.Login == login);

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

                    return Ok(new DataResponse<JurDocProject>
                    {
                        Data = projectByOwners[0],
                        Status = 200
                    });
                }

                return BadRequest(new DataResponse<JurDocProject>
                {
                    Data = null,
                    Status = 400,
                    MessageToUser = "Нет прав для использования данного проекта"
                });
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest(new DataResponse<JurDocProject>
                {
                    Data = null,
                    Status = 400,
                    Errors = [e.ToString()],
                    MessageToUser = "Нет прав для использования данного проекта"
                });
            }
        }


        [HttpPost]
        [SwaggerOperation("Создать пустой проект", "Создать пустой проект")]
        [ProducesResponseType(typeof(JurDocProject), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> Post()
        {
            try
            {
                var login = GetUserLogin();

                var user = await _dbContext.Set<JurDocUser>().FirstAsync(x => x.Login == login);

                var jurDocProject = new JurDocProject { OwnerId = user.Id };

                var jdProject = await _dbContext.AddAsync(jurDocProject);
                await _dbContext.SaveChangesAsync();

                return Ok(jurDocProject);
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(JurDocProject), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Put([FromBody] JurDocProject project)
        {
            try
            {
                var login = GetUserLogin();

                var user = await _dbContext.Set<JurDocUser>().FirstAsync(x => x.Login == login);

                var changedProject = await _dbContext.Set<JurDocProject>().FirstOrDefaultAsync(x => x.OwnerId == user!.Id && x.Id == project.Id);

                if (changedProject == null)
                {
                    return BadRequest("Нет прав на изменение проекта");
                }

                changedProject.Name = project.Name;
                changedProject.FullName = project.FullName;
                changedProject.OwnerId = project.OwnerId;

                await _dbContext.SaveChangesAsync();

                return Ok(changedProject);
            }
            catch (DbUpdateException e)
            {
                _logger?.LogError(e, message: null);
                return BadRequest("Ошибка при обновлении проекта");
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest();
            }
        }

        [HttpDelete]
        [SwaggerOperation("Удалить проект", "Удалить проект")]
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
