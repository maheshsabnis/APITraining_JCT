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
        AuthenticationService service;

        public AuthController(AuthenticationService service)
        {
            this.service = service;
        }

        [HttpPost]
        [ActionName("register")]
        public async Task<IActionResult> CreateUserAsync(RegisterUser user)
        { 
            var response = await service.CreateNewUserAsync(user);
            return Ok(response);
        }

        [HttpPost]
        [ActionName("login")]
        public async Task<IActionResult> AuthenticateUserAsync(LoginUser user)
        {
            var response = await service.AuthenticateAsync(user);
            return Ok(response);
        }

        [HttpPost]
        [ActionName("role")]
        public async Task<IActionResult> CreateRoleAsync(IdentityRole role)
        {
            var response = await service.CreateNewRoleAsync(role);
            return Ok(response);
        }

        [HttpPost]
        [ActionName("roletouser")]
        public async Task<IActionResult> AssgnRoleToUser(string rolename, string username)
        {
            var response = await service.AddUserToRoleAsync(rolename,username);
            return Ok(response);
        }


    }
}
