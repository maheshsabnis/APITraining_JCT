using Core_API.Models;
using Core_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authServ;
        public AuthController(AuthenticationService authServ)
        {
            _authServ = authServ;
        }


        [HttpPost]
        [ActionName("register")]
        public async Task<IActionResult> Register(RegisterUser user)
        { 
            var response = await _authServ.CreateNewUserAsync(user);
            if (response)
            {
                return Ok($"User {user.UserName} is created successfully");
            }
            return BadRequest("User Creation Failed");
        }


        [HttpPost]
        [ActionName("login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            var response = await _authServ.AuthenticateUser(user);
            if (response)
            {
                return Ok($"User {user.UserName} is loggied in successfully");
            }
            return BadRequest("User Login Failed");
        }


        [HttpPost]
        [ActionName("role")]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            var response = await _authServ.CreateNewRoleAsync(role);
            if (response)
            {
                return Ok($"User {role.Name} is created successfully");
            }
            return BadRequest("Role Creation Failed");
        }

        [HttpPost]
        [ActionName("roleuser")]
        public async Task<IActionResult> AssignRoleToUser(string userName, string roleName)
        {
            var response = await _authServ.AssignRoleToUserAsync(userName,roleName);
            return Ok(response);
        }

    }
}
