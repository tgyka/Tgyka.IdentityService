using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Data.Entities;
using Tgyka.IdentityService.Database.Mssql.Data.Repository;

namespace Tgyka.IdentityService.Data.Repositories.Abstractions
{
    public interface IRoleRepository: IBaseRepository<Role>
    {
    }
}
