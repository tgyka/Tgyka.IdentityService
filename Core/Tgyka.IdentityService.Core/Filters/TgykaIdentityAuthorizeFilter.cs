using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Core.Models;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Database.Mssql.Model;
using Tgyka.IdentityService.JwtHelper;
using Tgyka.IdentityService.JwtHelper.Models;

namespace Tgyka.IdentityService.Core.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class TgykaIdentityAuthorizeAttribute : TypeFilterAttribute
    {
        public TgykaIdentityAuthorizeAttribute(string roles = "", string permissions = "") : base(typeof(TgykaIdentityAuthorizeFilter))
        {
            Arguments = new object[] { roles, permissions };
        }
    }

    public class TgykaIdentityAuthorizeFilter : IAuthorizationFilter
    {
        private readonly JwtConfigModel _jwtConfig;
        private readonly string _roles;
        private readonly string _permissions;

        public TgykaIdentityAuthorizeFilter(JwtConfigModel jwtConfig, string roles, string permissions)
        {
            _jwtConfig = jwtConfig;
            _roles = roles;
            _permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = 401 };
                return;
            }

            try
            {
                var jwtToken = JwtValidator.ValidateJwt(token, _jwtConfig);
                var tokenUser = context.HttpContext.RequestServices.GetRequiredService<TokenUser>();

                tokenUser.Email = jwtToken.Claims.First(x => x.Type == "Email").Value;
                tokenUser.UserId = int.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);
                tokenUser.Username = jwtToken.Claims.First(x => x.Type == "Username").Value;

                var rolesString = jwtToken.Claims.First(x => x.Type == "Roles").Value;

                if(!string.IsNullOrEmpty(rolesString))
                    tokenUser.Roles = Array.ConvertAll(rolesString.Split(","), int.Parse);

                var permissionsString = jwtToken.Claims.First(x => x.Type == "Permissions").Value;

                if (!string.IsNullOrEmpty(permissionsString))
                    tokenUser.Permissions = Array.ConvertAll(permissionsString.Split(","), int.Parse);

                tokenUser.AccessToken = jwtToken.RawData;

                if (!string.IsNullOrEmpty(_roles))
                {
                    var requiredRoles = Array.ConvertAll(_roles.Split(','), int.Parse);

                    if (!requiredRoles.Any(role => tokenUser.Roles.ToList().Contains(role)))
                    {
                        context.Result = new JsonResult(new { message = "Unauthorized. User does not have the required roles." }) { StatusCode = 403 };
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(_permissions))
                {
                    var requiredPermissions = Array.ConvertAll(_permissions.Split(','), int.Parse);

                    if (!requiredPermissions.Any(permission => tokenUser.Permissions.ToList().Contains(permission)))
                    {
                        context.Result = new JsonResult(new { message = "Unauthorized. User does not have the required permissions." }) { StatusCode = 403 };
                        return;
                    }
                }


            }
            catch (Exception ex)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = 401 };
            }
        }
    }
}
