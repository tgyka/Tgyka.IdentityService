using Microsoft.EntityFrameworkCore;

namespace Tgyka.IdentityService.Database.Mssql.Data
{
    public class MssqlDbContext : DbContext
    {
        public MssqlDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
