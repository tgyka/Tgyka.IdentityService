using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Data.Repositories.Abstractions;
using Tgyka.IdentityService.Database.Mssql.Data.Repository;
using Tgyka.IdentityService.Database.Mssql.Data.UnitOfWork;
using Tgyka.IdentityService.Database.Mssql.Model.RepositoryDtos;

namespace Tgyka.IdentityService.Core.Services.Implementations
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public User Get(int id)
        {
            return _userRepository.Get(r => r.Id == id);    
        }

        public PaginationList<User> List(int page,int size)
        {
            return _userRepository.List(page: page, size: size);
        }

        public async Task<User> Create(User user)
        {
            var userResponse = _userRepository.Set(user,CommandState.Create);
            await _unitOfWork.CommitAsync();
            return userResponse;
        }

        public async Task<User> Update(User user)
        {
            var userResponse = _userRepository.Set(user, CommandState.Update);
            await _unitOfWork.CommitAsync();
            return userResponse;
        }

        public async Task<User> Delete(User user)
        {
            var userResponse = _userRepository.Set(user, CommandState.SoftDelete);
            await _unitOfWork.CommitAsync();
            return userResponse;
        }
    }
}
