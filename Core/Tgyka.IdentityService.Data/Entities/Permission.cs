﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgyka.IdentityService.Database.Mssql.Data.Entity;

namespace Tgyka.IdentityService.Data.Entities
{
    [Table("Tgyka_IdentityServer_Permissions")]
    public class Permission: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<RolePermission> RolePermissions { get; set; }
    }
}
