using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using static Project.Pages.Account.ExternalLoginModel;

namespace Project.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {

        private IConfiguration _configuration;

        public TokenController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post()
        {
            if (ModelState.IsValid)
            {
                //This method returns user id from username and password.
                //var userId = GetUserIdFromCredentials(loginViewModel);
                var userId = 1;
                if (userId == -1)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, "Abc"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                var token = new JwtSecurityToken
                (
                    issuer: _configuration["Issuer"],
                    audience: _configuration["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    //signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SigningKey"])),
                    //        SecurityAlgorithms.HmacSha256)
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("A04T1B2D-0ED6-4F28-B685-57D6101A9911")),
                            SecurityAlgorithms.HmacSha256)
                );
                string tokenNew = "";
                try
                {
                    tokenNew = new JwtSecurityTokenHandler().WriteToken(token);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
               
                return Ok(new { token = tokenNew });
            }

            return BadRequest();
        }
    }
}