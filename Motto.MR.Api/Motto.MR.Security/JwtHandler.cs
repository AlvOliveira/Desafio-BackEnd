using Microsoft.IdentityModel.Tokens;
using Motto.MR.Shared.Helper;
using Motto.MR.Shared.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Motto.MR.Security
{
    public static class JwtHandler
    {
        public static string GenerateJwtToken(User user)
        {
            var jwtSet = ReadSettings.GetJwtSettings();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtSet.JwtKey);
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return $"bearer {tokenHandler.WriteToken(token)}";
        }
    }
}
