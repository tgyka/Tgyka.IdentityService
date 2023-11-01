using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Database.Mssql.Model.RepositoryDtos;

namespace Tgyka.IdentityService.Core.Services.Abstractions
{
    public interface IPermissionService
    {
        Task<Permission> Create(Permission permission);
        Task<Permission> Delete(Permission permission);
        PaginationList<Permission> ListPermissionByRole(int roleId);
        PaginationList<Permission> ListPermissionByUser(int userId);
        Task<Permission> Update(Permission permission);
    }
}
