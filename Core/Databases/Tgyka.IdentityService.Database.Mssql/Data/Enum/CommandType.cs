using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgyka.IdentityService.Database.Mssql.Data.Enum
{
    public enum EntityCommandType
    {
        Create,
        Update,
        SoftDelete,
        HardDelete
    }
}
