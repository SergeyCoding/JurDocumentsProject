﻿using JurDocs.Common.Loggers;
using JurDocs.DbModel;
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

                var jurDocUserList = await _dbContext.Set<JurDocProject>()
                    .AsTracking()
                    .Where(x => x.OwnerId == user!.Id && !x.IsDeleted)
                    .ToArrayAsync();

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
