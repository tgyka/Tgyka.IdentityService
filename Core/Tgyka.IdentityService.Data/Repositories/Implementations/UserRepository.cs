using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Data.Repositories.Abstractions;
using Tgyka.IdentityService.Database.Mssql.Data;
using Tgyka.IdentityService.Database.Mssql.Data.Repository;
using Tgyka.IdentityService.Database.Mssql.Data.UnitOfWork;
using Tgyka.IdentityService.Database.Mssql.Model;

namespace Tgyka.IdentityService.Data.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MssqlDbContext dbContext, IUnitOfWork unitofWork, IMapper mapper, TokenUser tokenUser) : base(dbContext, unitofWork, mapper, tokenUser)
        {
        }
    }
}
