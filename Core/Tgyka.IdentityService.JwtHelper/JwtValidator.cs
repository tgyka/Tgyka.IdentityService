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
    public static class JwtValidator
    {
        public static JwtSecurityToken ValidateJwt(string token ,JwtConfigModel jwtConfigModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = jwtConfigModel.Audience,
                ValidIssuer = jwtConfigModel.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfigModel.Secret))
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }
    }
}
