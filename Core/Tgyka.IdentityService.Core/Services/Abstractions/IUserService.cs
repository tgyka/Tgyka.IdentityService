using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Core.Models;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Database.Mssql.Model.RepositoryDtos;

namespace Tgyka.IdentityService.Core.Services.Abstractions
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<User> Delete(User user);
        User Get(int id);
        PaginationList<User> List(int page, int size);
        Task<User> Update(User user);
    }
}
