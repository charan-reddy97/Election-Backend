using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;
using VotingApp.Repository;

namespace UserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        IUserRepository userRepository;
        public UserLoginController(IUserRepository userRepository)
            {
                this.userRepository = userRepository;
                //this.candidateRepository = candidateRepository;
            }
            [HttpPost]
            public IActionResult Post(UserModel user)
            {
                var authuser = userRepository.FindByUserName(user.Email, user.Password);
                if (authuser != null)
                {

                    var jwtToken = GenerateJWTToken(authuser.Email, authuser.Role.ToString());

                    return Ok(new { Profile = authuser, Token = jwtToken });
                }
                else
                {
                    return Unauthorized("Login Failed");
                }
            }
            private string GenerateJWTToken(string userName, string role)
            {
                string jwtToken = string.Empty;
                var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is your secret "));
                var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, userName));
                claims.Add(new Claim(ClaimTypes.Role, role));

                var token = new JwtSecurityToken("voting.com", "voting.com", claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
                jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return jwtToken;
            }
        }
    }

