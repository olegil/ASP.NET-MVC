using BLLEntities;
using BLLTransform;
using DALEntities;
using DALFactory;
using DALInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLServices
{
    public static class RoleBLLService
    {
        public static RoleEntity GetRole(int RoleId)
        {
            RoleIRepository RoleRepository = RepositoryFactory.GetRoleRepository();
            return new RoleEntity(RoleRepository.GetRole(RoleId));
        }

        public static int GetRoleId(string RoleName)
        {
            RoleIRepository RoleRepository = RepositoryFactory.GetRoleRepository();
            return RoleRepository.GetRoleId(RoleName);
        }

        public static IEnumerable<string> GetAllRoleNames()
        {
            RoleIRepository RoleRepository = RepositoryFactory.GetRoleRepository();
            return RoleRepository.GetAllRoleNames();
        }
    }
}
