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

namespace Tgyka.IdentityService.Data.Repositories.Implementations
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(MssqlDbContext dbContext, IUnitOfWork unitofWork, IMapper mapper) : base(dbContext, unitofWork, mapper)
        {
        }
    }
}
