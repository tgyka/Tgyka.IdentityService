using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Core.Services.Abstractions;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Data.Repositories.Abstractions;
using Tgyka.IdentityService.Database.Mssql.Data.Enum;
using Tgyka.IdentityService.Database.Mssql.Data.UnitOfWork;

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
            return _userRepository.GetOne(r => r.Id == id);    
        }

        public List<User> GetAll(int page,int size)
        {
            return _userRepository.GetAll(page: page, size: size);
        }

        public async Task<User> Create(User user)
        {
            _userRepository.SetEntityState(user,EntityCommandType.Create);
            await _unitOfWork.CommitAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _userRepository.SetEntityState(user, EntityCommandType.Update);
            await _unitOfWork.CommitAsync();
            return user;
        }

        public async Task<User> Delete(User user)
        {
            _userRepository.SetEntityState(user, EntityCommandType.SoftDelete);
            await _unitOfWork.CommitAsync();
            return user;
        }
    }
}
