using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Data.Repositories.Abstractions;
using Tgyka.IdentityService.JwtHelper;

namespace Tgyka.IdentityService.Core.Services.Implementations
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Login(string username,string password)
        {
            //TODO: password service
            var encrpytPassword = password;
            var user = _userRepository.Get(r => r.Username == username && r.Password == encrpytPassword);
            
            if(user == null)
            {
                return "Error";
            }

            return JwtGenerator.GenerateJwtToken(username, 30);
        }
    }
}
