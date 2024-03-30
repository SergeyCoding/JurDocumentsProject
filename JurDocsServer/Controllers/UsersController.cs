using DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocsServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public UsersController(JurDocsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [SwaggerOperation("Вывести пользователей", "Вывести пользователей", Tags = ["Пользователи"])]
        public async Task<IActionResult> Get()
        {
            var users = await _dbContext.Set<JurDocUser>().ToArrayAsync();

            return Ok(users);
        }

        [HttpPost]
        [SwaggerOperation("Добавить пользователей", "Добавить пользователей", Tags = ["Пользователи"])]
        public async Task<IActionResult> Post([FromBody] UserRequest userRequest)
        {
            var users = await _dbContext.Set<JurDocUser>().ToArrayAsync();

            if (users.Length != 1)
                return BadRequest();

            var user = users.First();
            return base.Ok(new UserResponse(user.Id, user.Path));
        }

        public record UserRequest(string UserName);
        public record UserResponse(int UserId, string Path);
    }
}
