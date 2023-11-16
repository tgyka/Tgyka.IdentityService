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

namespace Tgyka.IdentityService.Core.Services.Implementations
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtConfigModel _jwtConfigModel;

        public AuthenticationService(IUserRepository userRepository, JwtConfigModel jwtConfigModel)
        {
            _userRepository = userRepository;
            _jwtConfigModel = jwtConfigModel;
        }

        public LoginResponseModel Login(string username,string password)
        {
            //TODO: password service
            var encrpytPassword = password;
            var user = _userRepository.Get(r => r.Username == username && r.Password == encrpytPassword);
            
            if(user == null)
            {
                return null;
            }

            return new LoginResponseModel
            {
                AccessToken = JwtGenerator.GenerateJwtToken(new JwtModel(user.Id, user.Username, user.Email, _jwtConfigModel)),
                Email = user.Email,
                UserId = user.Id,
                Username = user.Username
            };
        }
    }
}
