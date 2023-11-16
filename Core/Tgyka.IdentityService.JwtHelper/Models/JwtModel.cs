using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgyka.IdentityService.JwtHelper.Models
{
    public class JwtModel
    {
        public JwtModel(int userId, string username, string email, JwtConfigModel jwtConfig)
        {
            UserId = userId;
            Username = username;
            Email = email;
            JwtConfig = jwtConfig;
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public JwtConfigModel JwtConfig { get; set; }

    }
}
