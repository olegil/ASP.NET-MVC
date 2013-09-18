using DALEntities;
using DALInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALDatabase
{
    public class UserDAL : UserIRepository
    {
        public User GetUser(int Id)
        {
            using (var DB = new DatabaseEntities())
            {
                return new User(DB.User.ToArray().First(user => user.UserId == Id));
            }
        }

        public User GetUserByLogin(string login)
        {
            try
            {
                using (var DB = new DatabaseEntities())
                {
                    return new User(DB.User.First(user => user.UserLogin == login));
                }
            }
            catch(InvalidOperationException)
            {
                return new User();
            }
        }

        public User GetUserByOpenID(string OpenID)
        {
            try
            {
                using (var DB = new DatabaseEntities())
                {
                    return new User(DB.User.First(user => user.UserOpenID == OpenID));
                }
            }
            catch (InvalidOperationException)
            {
                return new User();
            }
        }

        public int GetUserIdByLogin(string login)
        {
            try
            {
                using (var DB = new DatabaseEntities())
                {
                    return DB.User.First(user => user.UserLogin == login).UserId;
                }
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var DB = new DatabaseEntities())
            {
                if (DB.User.Count() != 0)
                {
                    return new User(DB.User.First(user => user.UserEmail == email));
                }
                else
                {
                    return new User();
                }
            }
        }

        public bool ActivateUser(int UserId)
        {
            using (var DB = new DatabaseEntities())
            {
                var DBUser = DB.User.ToArray().First(user => user.UserId == UserId);
                DBUser.UserIsActivated = true;
                DBUser.UserActivateKey = null;
                DB.SaveChanges();
                return true;
            }
        }

        public bool SaveUser(User user)
        {
            using (var DB = new DatabaseEntities())
            {
                DB.User.Add(user);
                DB.SaveChanges();
                return true;
            }
        }

        public bool SaveUserChanges(User User)
        {
            using (var DB = new DatabaseEntities())
            {
                var DBUser = DB.User.ToArray().First(user => user.UserId == User.UserId);
                DBUser = User;
                DB.SaveChanges();
                return true;
            }
        }

        public User[] GetUsersByUsersId(int[] UsersId)
        {
            using (var DB = new DatabaseEntities())
            {
                User[] Users = new User[UsersId.Length];
                for (int i = 0; i < UsersId.Length; i++)
                {
                    Users[i] = GetUser(UsersId[i]);
                }
                return Users;
            }
        }

        public string[] GetUserRights(string UserName)
        {
            return GetUserByLogin(UserName).Role.Select(role => role.RoleName).ToArray();
        }

        public string[] GetUserRights(int UserId)
        {
            return GetUser(UserId).Role.Select(role => role.RoleName).ToArray();
        }

        public void AddUserRole(int UserId, int RoleId)
        {
            using (var DB = new DatabaseEntities())
            {
                DB.User.First(user => user.UserId == UserId).Role.Add(DB.Role.First(role => role.RoleId == RoleId));
                DB.SaveChanges();
            }
        }

        public void RemoveUserRole(int UserId, int RoleId)
        {
            using (var DB = new DatabaseEntities())
            {
                DB.User.First(user => user.UserId == UserId).Role.Remove(DB.Role.First(role => role.RoleId == RoleId));
                DB.SaveChanges();
            }
        }

        public void ChangeUserStatus(int UserId)
        {
            using (var DB = new DatabaseEntities())
            {
                bool Value = !DB.User.First(user => user.UserId == UserId).UserIsActive;
                DB.User.First(user => user.UserId == UserId).UserIsActive = Value;
                DB.SaveChanges();
            }
        }

        public User[] GetAllUsers()
        {
            using (var DB = new DatabaseEntities())
            {
                var Users = DB.User.ToArray();
                User[] Result = new User[Users.Length];
                for (int i = 0; i < Users.Length; i++)
                {
                    Result[i] = new User(Users[i]);
                }
                return Result;
            }
        }

        public bool ContainsUserRole(int UserId, string RoleName)
        {
            using (var DB = new DatabaseEntities())
            {
                foreach (var role in DB.User.First(user => user.UserId == UserId).Role)
                {
                    if (role.RoleName == RoleName)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public IEnumerable<User> GetUsersContainsString(string SearchText)
        {
            using (var DB = new DatabaseEntities())
            {
                List<User> Result = new List<User>();
                SearchText = SearchText.ToLower();
                foreach (var user in DB.User)
                {
                    if (user.UserLogin.ToLower().Contains(SearchText))
                    {
                        Result.Add(user);
                    }
                }
                return Result;
            }
        }

        public IEnumerable<string> GetUserRoleNames(int UserId)
        {
            using (var DB = new DatabaseEntities())
            {
                return DB.User.First(user => user.UserId == UserId).Role.Select(role => role.RoleName).ToArray();
            }
        }
    }
}
