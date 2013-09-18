using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterface
{
    public interface UserIRepository
    {
        User GetUser(int Id);
        User GetUserByLogin(string login);
        User GetUserByOpenID(string OpenID);
        int GetUserIdByLogin(string login);
        User GetUserByEmail(string Email);
        bool ActivateUser(int Id);
        bool SaveUser(User user);
        bool SaveUserChanges(User user);
        User[] GetUsersByUsersId(int[] UsersId);
        string[] GetUserRights(string UserName);
        string[] GetUserRights(int UserId);
        void AddUserRole(int UserId, int RoleId);
        void RemoveUserRole(int UserId, int RoleId);
        void ChangeUserStatus(int UserId);
        User[] GetAllUsers();
        bool ContainsUserRole(int UserId, string RoleName);
        IEnumerable<User> GetUsersContainsString(string SearchText);
        IEnumerable<string> GetUserRoleNames(int UserId);
    }
}
