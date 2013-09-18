using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLEntities
{
    public class RoleEntity
    {
        public RoleEntity()
        {
            this.User = new HashSet<UserEntity>();
        }

        public RoleEntity(Role role)
        {
            RoleId = role.RoleId;
            RoleName = role.RoleName;
            User = new HashSet<UserEntity>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserEntity> User { get; set; }
    }
}
