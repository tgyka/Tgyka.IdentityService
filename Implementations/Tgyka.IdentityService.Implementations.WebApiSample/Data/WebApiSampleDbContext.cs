using Microsoft.EntityFrameworkCore;
using Tgyka.IdentityService.Data;

namespace Tgyka.IdentityService.Implementations.WebApiSample.Data
{
    public class WebApiSampleDbContext : TgykaIdentityServerDbContext
    {
        public WebApiSampleDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
