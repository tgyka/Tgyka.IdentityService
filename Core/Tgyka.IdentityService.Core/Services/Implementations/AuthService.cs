using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Core.Models;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Data.Repositories.Abstractions;
using Tgyka.IdentityService.JwtHelper;
using Tgyka.IdentityService.JwtHelper.Models;
using Tgyka.IdentityService.PasswordHelper;

namespace Tgyka.IdentityService.Core.Services.Implementations
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtConfigModel _jwtConfigModel;

        public AuthService(IUserRepository userRepository, JwtConfigModel jwtConfigModel)
        {
            _userRepository = userRepository;
            _jwtConfigModel = jwtConfigModel;
        }

        public LoginResponseModel Login(string username,string password)
        {
            var user = _userRepository.GetOne(r => r.Username == username && PasswordValidator.VerifyPassword(password , r.Password));
            
            if(user == null)
            {
                return null;
            }

            return new LoginResponseModel
            {
                AccessToken = JwtGenerator.GenerateJwt(new JwtModel(user.Id, user.Username, user.Email, _jwtConfigModel)),
                Email = user.Email,
                UserId = user.Id,
                Username = user.Username
            };
        }
    }
}
