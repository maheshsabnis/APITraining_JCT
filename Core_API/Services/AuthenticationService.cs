using Core_API.Models;
using Microsoft.AspNetCore.Identity;

namespace Core_API.Services
{
    public class AuthenticationService
    {
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        SignInManager<IdentityUser> _signInManager;

        public AuthenticationService(RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;

            _signInManager = signInManager;

            _userManager = userManager;
        }
        /// <summary>
        /// THis method is used to register new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> CreateNewUserAsync(RegisterUser user)
        {
            // STore the RegisterUser data in IdentityUser class
            IdentityUser identityUser = new IdentityUser()
            {
                 Email = user.UserName,
                 UserName = user.UserName
            };
            // CReate new User
            var result = await _userManager.CreateAsync(identityUser, user.Password);
            if(result.Succeeded) return true;   
            return false;
        }
        /// <summary>
        /// Method to Authenticate the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> AuthenticateAsync(LoginUser user)
        {
            // authenticate user based on username and password
            // the third parameter is false because no cookie will be created
            // the fourth parameter will be used for lockout the user
            // for 3 invalid login attempts
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password,false,true);
            return result.Succeeded;
        }

        public async Task<bool> CreateNewRoleAsync(IdentityRole role)
        { 
            var result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }

        public async Task<string> AddUserToRoleAsync(string rolename, string username)
        { 
            // 1. check role exist
            var IsRoleExist = await _roleManager.RoleExistsAsync(rolename);
            if (!IsRoleExist) 
            {
                return $"Role with Name {rolename} does nt exist";
            }
            // 2. check user exist
            IdentityUser user = await _userManager.FindByNameAsync(username);
            if (user == null) 
            {
                return $"USer with name {username} does not exist";
            }

            // 3. Assign Role to User
            var result = await _userManager.AddToRoleAsync(user,rolename);
            if (result.Succeeded)
                return $"Role {rolename} is successfully assigned to user {username}";

            return $"Role {rolename} can ot be assigned to user {username}"; 
        }

    }
}
