using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tgyka.IdentityService.Core.Filters;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Core.Services.Implementations;
using Tgyka.IdentityService.Data.Entities;

namespace Tgyka.IdentityService.Implementations.WebApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TgykaIdentityAuthorize(roles: "1,2")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_userService.Get(id));
        }

        [HttpGet("getAll")]
        public IActionResult GetAll(int page, int size)
        {
            return Ok(_userService.List(page,size));
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            return Ok(_userService.Update(user));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var user = _userService.Get(id);
            return Ok(_userService.Delete(user));
        }
    }
}
