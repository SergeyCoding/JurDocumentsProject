using DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JurDocs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public ProjectController(JurDocsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var claim = User.Claims.FirstOrDefault(x => x.Type == "Login");

            if (claim == null)
                return BadRequest();

            var jurDocUser = _dbContext.Set<JurDocUser>().FirstOrDefault();

            return Ok();
        }
    }
}
