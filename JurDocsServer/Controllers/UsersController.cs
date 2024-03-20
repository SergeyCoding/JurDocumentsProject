using JurDocsServer.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JurDocsServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SecurityInfoReader _reader;

        public UsersController(SecurityInfoReader reader)
        {
            _reader = reader;
        }


        [HttpPost]
        public ActionResult<UserResponse> Get([FromBody] UserRequest userRequest)
        {
            var securityInfo = _reader.GetSecurityInfo();

            var users = securityInfo.Users!.Where(x => x.Name == userRequest.UserName).ToArray();

            if (users.Length != 1)
                return BadRequest();

            var user = users.First();
            return base.Ok(new UserResponse(user.Id, user.Path));
        }

        public record UserRequest(string UserName);
        public record UserResponse(int UserId, string Path);
    }
}
