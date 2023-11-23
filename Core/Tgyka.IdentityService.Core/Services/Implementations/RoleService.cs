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

namespace Tgyka.IdentityService.Core.Services.Implementations
{
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;


        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public Role Get(int id)
        {
            return _roleRepository.GetOne(r => r.Id == id);
        }

        public List<Role> GetRolesByUser(int userId)
        {
            return _roleRepository.GetAll(r => r.UserRoles.Any(r => r.UserId == userId));
        }

        public List<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public async Task<Role> Create(Role role)
        {
            _roleRepository.SetEntityState(role, EntityCommandType.Create);
            await _unitOfWork.CommitAsync();
            return role;
        }

        public async Task<Role> Update(Role role)
        {
            _roleRepository.SetEntityState(role, EntityCommandType.Update);
            await _unitOfWork.CommitAsync();
            return role;
        }

        public async Task<Role> Delete(Role role)
        {
            _roleRepository.SetEntityState(role, EntityCommandType.SoftDelete);
            await _unitOfWork.CommitAsync();
            return role;
        }
    }
}
