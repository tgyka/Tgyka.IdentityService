using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.JwtHelper.Models;

namespace Tgyka.IdentityService.JwtHelper
{
    public static class JwtGenerator
    {
        public static string GenerateJwt(JwtModel jwtModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtModel.JwtConfig.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("Username", jwtModel.Username),
                new Claim("UserId", jwtModel.UserId.ToString()),
                new Claim("Email", jwtModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: jwtModel.JwtConfig.Issuer,
                audience: jwtModel.JwtConfig.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtModel.JwtConfig.ExpireMinute),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
