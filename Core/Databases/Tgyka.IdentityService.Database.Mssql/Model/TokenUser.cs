using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgyka.IdentityService.Database.Mssql.Model
{
    public class TokenUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int[] Roles { get; set; }
        public int[] Permissions  { get; set; }
        public string AccessToken { get; set; }
    }
}
