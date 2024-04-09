using JurDocs.DbModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public PersonController(JurDocsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [SwaggerOperation("Сотрудники", "Сотрудники")]
        [HttpGet]
        [ProducesResponseType(typeof(List<PersonGetResponse>), 200)]
        public async Task<IActionResult> Get()
        {
            var users = await _dbContext.Set<JurDocUser>()
                .AsNoTracking()
                .Where(x => x.Login != "root")
                .Select(x => new { x.Name, x.Id })
                .ToArrayAsync();

            return Ok(users.Select(x => new PersonGetResponse(x.Id, x?.Name ?? string.Empty)));
        }

        public record PersonGetResponse(int PersonId, string PersonName);
    }
}
