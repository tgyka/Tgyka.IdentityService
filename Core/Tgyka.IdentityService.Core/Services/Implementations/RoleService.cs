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
            return _roleRepository.Get(r => r.Id == id);
        }

        public PaginationList<Role> ListRolesByUser(int userId)
        {
            return _roleRepository.List(r => r.UserRoles.Any(r => r.UserId == userId));
        }

        public PaginationList<Role> List()
        {
            return _roleRepository.List();
        }

        public async Task<Role> Create(Role role)
        {
            var roleResponse = _roleRepository.Set(role, CommandState.Create);
            await _unitOfWork.CommitAsync();
            return roleResponse;
        }

        public async Task<Role> Update(Role role)
        {
            var roleResponse = _roleRepository.Set(role, CommandState.Update);
            await _unitOfWork.CommitAsync();
            return roleResponse;
        }

        public async Task<Role> Delete(Role role)
        {
            var roleResponse = _roleRepository.Set(role, CommandState.SoftDelete);
            await _unitOfWork.CommitAsync();
            return roleResponse;
        }
    }
}
