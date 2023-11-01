using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgyka.IdentityService.Core.Services.Abstractions
{
    public interface IAuthenticationService
    {
        string Login(string username,string password);
    }
}
