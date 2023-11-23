using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Core.Services.Implementations;
using Tgyka.IdentityService.Data;
using Tgyka.IdentityService.Data.Repositories.Abstractions;
using Tgyka.IdentityService.Data.Repositories.Implementations;
using Tgyka.IdentityService.Database.Mssql.Model;
using Tgyka.IdentityService.JwtHelper.Models;

namespace Tgyka.IdentityService.Core
{
    public static class DependencyResolver
    {
        public static void AddIdentityService<TDbContext>(this IServiceCollection services,IConfiguration configuration) where TDbContext: TgykaIdentityServerDbContext
        {
            AddServices(services);
            AddRepositories(services);
            services.AddScoped<TokenUser>();
            services.AddScoped<TgykaIdentityServerDbContext,TDbContext>();
            JwtConfigModel jwtConfigModel = new();
            configuration.GetSection("JwtSettings").Bind(jwtConfigModel);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPermissionService, PermissionService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
        }
    }
}
