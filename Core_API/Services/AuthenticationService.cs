using Core_API.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace Core_API.Services
{
    /// <summary>
    /// This class will contain Methods to Create and Autehnticate USers
    /// as well as create roles and add user to role
    /// </summary>
    public class AuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;

            _roleManager = roleManager;

            _userManager = userManager;
        }

        public async Task<bool> CreateNewUserAsync(RegisterUser user)
        {
            var identityUser = new IdentityUser() 
            {
               Email = user.UserName,
               UserName = user.UserName
            };

            // This methdo will Auto-has the password
            var result = await _userManager.CreateAsync(identityUser, user.Password);

            if(result.Succeeded) return true;
            return false;
        }


        public async Task<bool> AuthenticateUser(LoginUser user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);
            
            if (result.Succeeded) return true;
            return false;
        }

        public async Task<bool> CreateNewRoleAsync(IdentityRole role)
        {
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded) return true;
            return false;
        }

        public async Task<ResponseObject> AssignRoleToUserAsync(string userName, string roleName)
        {
            ResponseObject response = new ResponseObject();

            // 1. Check if role exist
            var IsRoleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!IsRoleExist)
            {
                response.Message = $"Role with name {roleName} does not exist";
                return response;
            }

            // 2. Check if User Exists
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                response.Message = $"User with name {userName} does not exist";
                return response;
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded) 
            {
                response.Message = $"User with name {userName} is added to role with name {roleName}";
                return response;
            }
            response.Message = $"Some Error has occured while adding  user {userName} to role {roleName}";

            return response;

        }
    }
}
