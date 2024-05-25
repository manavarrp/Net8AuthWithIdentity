using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Net8AuthenticationWithidentityWebApi.Entities;
using Net8AuthenticationWithidentityWebApi.Entities.Dto;

namespace Net8AuthenticationWithidentityWebApi.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> Register(UserDto model)
        {
            var user = new User()
            {
                FullName = model.FullName,
                Email = model.Email,
                Contact = model.Contact,
                Address = model.Address,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                PasswordHash = model.Password,

            };
            var result = await _userManager.CreateAsync(user, user.PasswordHash!);
            if (result.Succeeded) return Ok("Registration made sucessfully");
            return BadRequest(result.Errors);


        }

        [HttpPost("singin")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(
                userName: email,
                password: password,
                isPersistent: false,
                lockoutOnFailure: false
                );
            if (signInResult.Succeeded) return Ok("You are succesfully logged in");
            return BadRequest("Error ocurred");
        }

    }
}
