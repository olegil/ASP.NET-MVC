using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterface
{
    public interface RoleIRepository
    {
        Role GetRole(int RoleId);
        int GetRoleId(string RoleName);
        IEnumerable<string> GetAllRoleNames();
    }
}
