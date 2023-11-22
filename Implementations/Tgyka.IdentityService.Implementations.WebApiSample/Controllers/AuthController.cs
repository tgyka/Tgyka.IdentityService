using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tgyka.IdentityService.Core.Models;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Data.Entities;

namespace Tgyka.IdentityService.Implementations.WebApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            return Ok(_authService.Login(username, password));
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            return Ok(_userService.Create(user));
        }
    }
}
