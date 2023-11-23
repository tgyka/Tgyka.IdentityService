using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Database.Mssql.Model;

namespace Tgyka.IdentityService.Core.Services.Abstractions
{
    public interface IRoleService
    {
        Task<Role> Create(Role role);
        Task<Role> Delete(Role role);
        Role Get(int id);
        List<Role> GetAll();
        List<Role> GetRolesByUser(int userId);
        Task<Role> Update(Role role);
    }
}
