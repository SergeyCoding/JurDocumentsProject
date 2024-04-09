using JurDocs.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private const string Tag = "*Пользователи";

        private readonly JurDocsDbContext _dbContext;

        public UsersController(JurDocsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [SwaggerOperation("Вывести пользователей", "Вывести пользователей", Tags = [Tag])]
        public async Task<IActionResult> Get()
        {
            var users = await _dbContext.Set<JurDocUser>().ToArrayAsync();

            foreach (var item in users)
                item.Password = string.Empty;

            return Ok(users);
        }

        [HttpPost]
        [SwaggerOperation("Добавить пользователей", "Добавить пользователей", Tags = [Tag])]
        public async Task<IActionResult> Post([FromBody] JurDocUser[] users)
        {
            try
            {
                foreach (var item in users)
                {
                    var jurDocUser = _dbContext.Set<JurDocUser>().FirstOrDefault(x => x.Login == item.Login);

                    if (jurDocUser == null)
                    {
                        item.Id = 0;
                        await _dbContext.Set<JurDocUser>().AddAsync(item);
                        await _dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        jurDocUser.Path = item.Path;
                        jurDocUser.Name = item.Name;

                        if (item.Password != string.Empty)
                            jurDocUser.Password = item.Password;

                        await _dbContext.SaveChangesAsync();
                    }

                }

                return Ok();
            }
            catch (Exception)
            {
            }

            return BadRequest();
        }

        [HttpDelete]
        [SwaggerOperation("Удалить пользователя", "Удалить пользователя", Tags = [Tag])]
        public async Task<IActionResult> Delete([FromBody] JurDocUser user)
        {
            try
            {
                var jurDocUser = _dbContext.Set<JurDocUser>().FirstOrDefault(x => x.Login == user.Login);

                if (jurDocUser == null)
                    return BadRequest("Такого пользователя нет");

                _dbContext.Remove(jurDocUser);
                await _dbContext.SaveChangesAsync();

                return Ok("Пользователь удален");
            }
            catch (Exception)
            {
            }

            return BadRequest("Произошла ошибка");
        }

    }
}
