using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Core.Models;

namespace Tgyka.IdentityService.Core.Services.Abstractions
{
    public interface IAuthService
    {
        AuthModel Login(string username,string password);
    }
}
