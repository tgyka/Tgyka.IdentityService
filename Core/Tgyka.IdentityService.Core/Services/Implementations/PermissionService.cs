using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Data.Repositories.Abstractions;
using Tgyka.IdentityService.Data.Repositories.Implementations;
using Tgyka.IdentityService.Database.Mssql.Data.Enum;
using Tgyka.IdentityService.Database.Mssql.Data.Repository;
using Tgyka.IdentityService.Database.Mssql.Data.UnitOfWork;
using Tgyka.IdentityService.Database.Mssql.Model;

namespace Tgyka.IdentityService.Core.Services.Implementations
{
    public class PermissionService: IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
        {
            _permissionRepository = permissionRepository;
            _unitOfWork = unitOfWork;
        }

        public Permission Get(int id)
        {
            return _permissionRepository.GetOne(r => r.Id == id);
        }

        public List<Permission> GetPermissionsByRole(int roleId)
        {
            return _permissionRepository.GetAll(r => r.RolePermissions.Any(k => k.RoleId == roleId));
        }

        public List<Permission> GetPermissionsByUser(int userId)
        {
            return _permissionRepository.GetAll(r => r.RolePermissions.Any(k => k.Role.UserRoles.Any(t => t.UserId == userId)));
        }

        public async Task<Permission> Create(Permission permission)
        {
            _permissionRepository.SetEntityState(permission, EntityCommandType.Create);
            await _unitOfWork.CommitAsync();
            return permission;
        }

        public async Task<Permission> Update(Permission permission)
        {
            _permissionRepository.SetEntityState(permission, EntityCommandType.Update);
            await _unitOfWork.CommitAsync();
            return permission;
        }

        public async Task<Permission> Delete(Permission permission)
        {
            _permissionRepository.SetEntityState(permission, EntityCommandType.SoftDelete);
            await _unitOfWork.CommitAsync();
            return permission;
        }
    }
}
