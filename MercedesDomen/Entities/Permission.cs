using System;
using System.Collections.Generic;
using System.Text;

namespace Domen.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; } = new HashSet<RolePermission>();
    }
}
