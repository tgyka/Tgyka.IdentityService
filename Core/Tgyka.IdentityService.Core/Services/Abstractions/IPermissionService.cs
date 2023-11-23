using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Database.Mssql.Model;

namespace Tgyka.IdentityService.Core.Services.Abstractions
{
    public interface IPermissionService
    {
        Task<Permission> Create(Permission permission);
        Task<Permission> Delete(Permission permission);
        Permission Get(int id);
        List<Permission> GetPermissionsByRole(int roleId);
        List<Permission> GetPermissionsByUser(int userId);
        Task<Permission> Update(Permission permission);
    }
}
