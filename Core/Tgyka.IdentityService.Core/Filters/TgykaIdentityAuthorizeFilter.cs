using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Core.Models;
using Tgyka.IdentityService.JwtHelper.Models;

namespace Tgyka.IdentityService.Core.Filters
{
    public class TgykaIdentityAuthorizeFilter : IAuthorizationFilter
    {
        private JwtConfigModel _jwtConfig;

        public TgykaIdentityAuthorizeFilter(JwtConfigModel jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = 401 };
                return;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("YourSecretKey"); // JWT'nin imzalamak için kullanılan gizli anahtar

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = _jwtConfig.Audience,
                    ValidIssuer = _jwtConfig.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret))
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var tokenUser = context.HttpContext.RequestServices.GetRequiredService<TokenUser>();

                tokenUser.Email = jwtToken.Claims.First(x => x.Type == "Email").Value;
                tokenUser.UserId = Int32.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);
                tokenUser.Username = jwtToken.Claims.First(x => x.Type == "Username").Value;
                tokenUser.AccessToken = jwtToken.RawData;

                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "sub").Value);

            }
    }
}
