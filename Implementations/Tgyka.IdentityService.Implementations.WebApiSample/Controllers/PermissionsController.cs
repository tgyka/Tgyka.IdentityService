using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Data.Entities;

namespace Tgyka.IdentityService.Implementations.WebApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet("getAllByUserId")]
        public IActionResult GetAllByUserId(int userId)
        {
            return Ok(_permissionService.ListPermissionByUser(userId));
        }

        [HttpGet("getAllByRoleId")]
        public IActionResult GetAllByRoleId(int roleId)
        {
            return Ok(_permissionService.ListPermissionByRole(roleId));
        }

        [HttpPost]
        public IActionResult Create(Permission permission)
        {
            return Ok(_permissionService.Create(permission));
        }

        [HttpPut]
        public IActionResult Update(Permission permission)
        {
            return Ok(_permissionService.Update(permission));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var user = _permissionService.Get(id);
            return Ok(_permissionService.Delete(user));
        }
    }
}
