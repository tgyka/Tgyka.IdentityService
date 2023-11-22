using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tgyka.IdentityService.Database.Mssql.Data.Entity;

namespace Tgyka.IdentityService.Data.Entities
{
    [Table("Tgyka_IdentityServer_Users")]
    public class User: BaseEntity
    {
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}
