using JurDocs.DbModel;
using LexExchangeApi.Clients;
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
        [ProducesResponseType(typeof(List<string>), 200)]
        public async Task<IActionResult> Index()
        {
            var users = await _dbContext.Set<JurDocUser>().Select(x => x.Name).ToArrayAsync();

            return Ok(users);
        }
    }
}
