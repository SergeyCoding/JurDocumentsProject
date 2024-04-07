using DbModel;
using JurDocs.Common.Loggers;
using JurDocs.Server.Controllers.Base;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var login = GetUserLogin();

                var user = await _dbContext.Set<JurDocUser>().FirstAsync(x => x.Login == login);

                var jurDocUserList = await _dbContext.Set<JurDocProject>().Where(x => x.OwnerId == user!.Id).ToArrayAsync();

                return Ok(jurDocUserList);
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest();
            }
        }

        [HttpPost]
        [SwaggerOperation("Создать пустой проект", "Создать пустой проект")]
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
        public async Task<IActionResult> Put([FromBody] JurDocProject project)
        {
            try
            {
                var login = GetUserLogin();

                var user = await _dbContext.Set<JurDocUser>().FirstAsync(x => x.Login == login);

                var jurDocUserList = await _dbContext.Set<JurDocProject>().Where(x => x.OwnerId == user!.Id).ToArrayAsync();

                return Ok(jurDocUserList);
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest();
            }
        }

    }
}
