using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TwitterApi.Data.Entities;
using TwitterApi.Data.Models;
using TwitterApi.Data.UnitOfWork;

namespace TwitterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public IdentityController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }
        private bool AuthenticateUser(UserModel user)
        {
            var userName = _unitOfWork.Get<User>().Select(x => x.UserName).FirstOrDefault();
            var phoneNumber = _unitOfWork.Get<User>().Select(x => x.PhoneNumber).FirstOrDefault();

            if (user.UserName == userName && user.PhoneNumber == phoneNumber)
                return true;

            return false;
        }
        private string GenerateToken(UserModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "Test"));
            var credintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim("id","1"),
                new Claim("FirstName","amin"),
                new Claim("LasttName","roohbakhsh")
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credintials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            if (user is null || !AuthenticateUser(user))
            {
                return Unauthorized();
            }

            var token = GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}
