using DALEntities;
using DALInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALDatabase
{
    public class RoleDAL : RoleIRepository
    {
        public Role GetRole(int RoleId)
        {
            using (var DB = new DatabaseEntities())
            {
                return new Role(DB.Role.First(role => role.RoleId == RoleId));
            }
        }

        public int GetRoleId(string RoleName)
        {
            using (var DB = new DatabaseEntities())
            {
                return DB.Role.First(role => role.RoleName == RoleName).RoleId;
            }
        }

        public IEnumerable<string> GetAllRoleNames()
        {
            using (var DB = new DatabaseEntities())
            {
                return DB.Role.Select(role => role.RoleName).ToArray();
            }
        }
    }
}
