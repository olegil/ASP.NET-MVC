using BLLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public partial class Role
    {
        public Role()
        {
            this.User = new HashSet<User>();
        }

        public Role(RoleEntity role)
        {
            RoleId = role.RoleId;
            RoleName = role.RoleName;
            User = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
