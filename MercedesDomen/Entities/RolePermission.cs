using System;
using System.Collections.Generic;
using System.Text;

namespace MercedesDomen.Entities
{
    public class RolePermission : Entity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

    }
}
