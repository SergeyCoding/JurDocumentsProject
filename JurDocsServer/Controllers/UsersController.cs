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


        [HttpGet]
        public ActionResult<int> Get([FromBody] UserRequest userRequest)
        {
            var securityInfo = _reader.GetSecurityInfo();

            var users = securityInfo.Users!.Where(x => x.Name == userRequest.UserName).ToArray();

            if (users.Length != 1)
                return BadRequest();

            return Ok(new UserResponse(users.First().Id));
        }

        public record UserRequest(string UserName);
        public record UserResponse(int UserId);
    }
}
