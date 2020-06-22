using System;
using System.Collections.Generic;
using System.Text;

namespace Domen.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; } = new HashSet<RolePermission>();
        public ICollection<User> Users { get; set; } = new HashSet<User>();

    }
}
