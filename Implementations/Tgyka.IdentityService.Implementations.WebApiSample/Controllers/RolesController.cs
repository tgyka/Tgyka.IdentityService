using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Core.Services.Implementations;
using Tgyka.IdentityService.Data.Entities;

namespace Tgyka.IdentityService.Implementations.WebApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("getAllByUserId")]
        public IActionResult GetAllByUserId(int userId)
        {
            return Ok(_roleService.ListRolesByUser(userId));
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            return Ok(_roleService.Create(role));
        }

        [HttpPut]
        public IActionResult Update(Role role)
        {
            return Ok(_roleService.Update(role));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var user = _roleService.Get(id);
            return Ok(_roleService.Delete(user));
        }
    }
}
