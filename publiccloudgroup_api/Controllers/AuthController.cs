using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using publiccloudgroup_api.DTO_s;
using publiccloudgroup_api.Interfaces;
using publiccloudgroup_api.Models;

namespace publiccloudgroup_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUser _userManager;
        private readonly IToken _tokenManager;

        public AuthController(IUser userManager, IToken tokenManager)
        {
            _userManager = userManager;
            _tokenManager = tokenManager;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] UserDto user)
        {
            var loginResult = await _userManager.GetUserByEmailAndPassword(user);

            if (loginResult.isError)
                return BadRequest(loginResult.responseMessage);

            var (isSuccess, errorMessage, token) = await _tokenManager.GenerateToken(user);

            if (!isSuccess)
                return BadRequest(errorMessage);

            return Ok(token);
        }
    }
}
