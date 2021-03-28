using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Teleperformance.API.Tooken;
using Teleperformance.Models.ViewModels;

namespace Teleperformance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationSettings appSettings;


        public HomeController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager, RoleManager<IdentityRole> _roleManager,  IOptions<ApplicationSettings> _appSettings)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            appSettings = _appSettings.Value;
        }




            


        #region LoginWithTooken
        [HttpPost]
        [Route("LoginWithTooken")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> LoginWithTooken(LoginModel model)
        {
            var userEmail = await userManager.FindByEmailAsync(model.Email);
            if (userEmail == null)
                return BadRequest(new { message = "Username or password is incorrect." });
            var user = await userManager.FindByNameAsync(userEmail.UserName);

            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new
                {
                    token,
                    userID = user.Id,
                    expires = tokenDescriptor.Expires,
                    
                });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }



        #endregion

      



    }
}
