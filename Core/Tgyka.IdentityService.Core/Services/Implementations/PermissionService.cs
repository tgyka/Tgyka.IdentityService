using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Data.Repositories.Abstractions;
using Tgyka.IdentityService.Data.Repositories.Implementations;
using Tgyka.IdentityService.Database.Mssql.Data.Repository;
using Tgyka.IdentityService.Database.Mssql.Data.UnitOfWork;
using Tgyka.IdentityService.Database.Mssql.Model.RepositoryDtos;

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
            return _permissionRepository.Get(r => r.Id == id);
        }

        public PaginationList<Permission> ListPermissionByRole(int roleId)
        {
            return _permissionRepository.List(r => r.RolePermissions.Any(k => k.RoleId == roleId));
        }

        public PaginationList<Permission> ListPermissionByUser(int userId)
        {
            return _permissionRepository.List(r => r.RolePermissions.Any(k => k.Role.UserRoles.Any(t => t.UserId == userId)));
        }

        public async Task<Permission> Create(Permission permission)
        {
            var permissionResponse = _permissionRepository.Set(permission, CommandState.Create);
            await _unitOfWork.CommitAsync();
            return permissionResponse;
        }

        public async Task<Permission> Update(Permission permission)
        {
            var permissionResponse = _permissionRepository.Set(permission, CommandState.Update);
            await _unitOfWork.CommitAsync();
            return permissionResponse;
        }

        public async Task<Permission> Delete(Permission permission)
        {
            var permissionResponse = _permissionRepository.Set(permission, CommandState.SoftDelete);
            await _unitOfWork.CommitAsync();
            return permissionResponse;
        }
    }
}
