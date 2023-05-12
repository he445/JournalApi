using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Entity.Entities;
using Apis.Model;
using Apis.Model.Token;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateIdentityToken")]
        public async Task<IActionResult> CreateIdentityToken([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Retrieve Logged-in User
                var userCurrent = await _userManager.FindByEmailAsync(login.Email);
                var userId = userCurrent.Id;

                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                    .AddSubject("Company - Everton inc")
                    .AddIssuer("Test.Securiry.Bearer")
                    .AddAudience("Test.Securiry.Bearer")
                    .AddClaim("userId", userId)
                    .AddExpiry(5)
                    .Builder();

                return Ok(token.value);
            }
            else
            {
                return Unauthorized();
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AddIdentityUser")]
        public async Task<IActionResult> AddIdentityUser([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return Ok("Missing some data");
            }

            var user = new ApplicationUser
            {
                Name = login.Name,
                Email = login.Email,
                Type = UserType.Common,
                UserName = login.Email
            };

            var result = await _userManager.CreateAsync(user, login.Password);

            if (result.Errors.Any())
            {
                return Ok(result.Errors);
            }

            // Generate confirmation code if needed
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // Return email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result2 = await _userManager.ConfirmEmailAsync(user, code);

            if (result2.Succeeded)
            {
                return Ok("User Added Successfully");
            }
            else
            {
                return Ok("Error confirming user");
            }
        }
    }
}
