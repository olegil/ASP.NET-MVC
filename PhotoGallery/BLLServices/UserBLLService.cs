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
    public static class UserBLLService
    {
        public static UserEntity GetUser(int Id)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            User Result = UserRepository.GetUser(Id);
            return new UserEntity(Result);
        }

        public static UserEntity GetUserByLogin(string login)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            User Result = UserRepository.GetUserByLogin(login);
            return new UserEntity(Result);
        }

        public static UserEntity GetUserByOpenID(string OpenID)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            User Result = UserRepository.GetUserByOpenID(OpenID);
            return new UserEntity(Result);
        }

        public static int GetUserIdByLogin(string login)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            return UserRepository.GetUserIdByLogin(login);
        }

        public static UserEntity GetUserByEmail(string email)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            User Result = UserRepository.GetUserByEmail(email);
            return new UserEntity(Result);
        }

        public static bool ActivateUser(int UserId)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            return UserRepository.ActivateUser(UserId);
        }

        public static bool SaveUser(UserEntity User)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            if (UserRepository.SaveUser(new User { 
                UserLogin = User.UserLogin,
                UserPassword = User.UserPassword,
                UserEmail = User.UserEmail,
                UserOpenID = User.UserOpenID,
                UserLastLoginDate = User.UserLastLoginDate,
                UserActivateKey = User.UserActivateKey,
                UserCreateDate = User.UserCreateDate,
                UserIsActivated = User.UserIsActivated,
                UserIsActive = User.UserIsActive,
                Role = Transform.RoleEntityToRole(User.Role),
                Comment = Transform.CommentEntityToComment(User.Comment),
                Image = Transform.ImageEntityToImage(User.Image)
            }))
                return true;
            else
                return false;
        }

        public static bool SaveUserChanges(UserEntity User)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            if (UserRepository.SaveUserChanges(new User
            {
                UserId = User.UserId,
                UserLogin = User.UserLogin,
                UserPassword = User.UserPassword,
                UserEmail = User.UserEmail,
                UserOpenID = User.UserOpenID,
                UserLastLoginDate = User.UserLastLoginDate,
                UserActivateKey = User.UserActivateKey,
                UserCreateDate = User.UserCreateDate,
                UserIsActivated = User.UserIsActivated,
                UserIsActive = User.UserIsActive,
                Role = Transform.RoleEntityToRole(User.Role),
                Comment = Transform.CommentEntityToComment(User.Comment),
                Image = Transform.ImageEntityToImage(User.Image)
            }))
                return true;
            else
                return false;
        }

        public static UserEntity[] GetUsersByUsersId(int[] UsersId)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            return Transform.UserToUserEntity(UserRepository.GetUsersByUsersId(UsersId));
        }

        public static string[] GetUserRights(string UserName)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            return UserRepository.GetUserRights(UserName);
        }

        public static string[] GetUserRights(int UserId)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            return UserRepository.GetUserRights(UserId);
        }

        public static void AddUserRole(int UserId, int RoleId)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            UserRepository.AddUserRole(UserId, RoleId);
        }

        public static void RemoveUserRole(int UserId, int RoleId)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            UserRepository.RemoveUserRole(UserId, RoleId);
        }

        public static void ChangeUserStatus(int UserId)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            UserRepository.ChangeUserStatus(UserId);
        }

        public static UserEntity[] GetAllUsers()
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            return Transform.UserToUserEntity(UserRepository.GetAllUsers());
        }

        internal static IEnumerable<User> GetUsersContainsString(string SearchText)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            return UserRepository.GetUsersContainsString(SearchText);
        }

        public static bool ContainsUserRole(int UserId, string RoleName)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            return UserRepository.ContainsUserRole(UserId, RoleName);
        }

        public static IEnumerable<string> GetUserRoleNames(int UserId)
        {
            UserIRepository UserRepository = RepositoryFactory.GetUserRepository();
            return UserRepository.GetUserRoleNames(UserId);
        }
    }
}
