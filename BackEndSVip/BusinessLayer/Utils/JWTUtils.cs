using DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Utils
{
    public static class JWTUtils
    {
        public static bool IsExpiredToken(this string token, DateTime now)
        {
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            if (jwt.ValidTo < now) return true;
            return false;
        }

        public static string GenerateJsonWebToken(this User user, string key, IConfiguration configuration)
        {
            var role = user.Role;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim("UserId", user.UserId.ToString()),
            new Claim("RoleId", role.ToString()),
        };
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
