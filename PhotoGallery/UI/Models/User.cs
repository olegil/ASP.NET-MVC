using BLLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class User
    {
        public User()
        {
            Role = new HashSet<Role>();
        }

        public User(UserEntity user)
        {
            UserId = user.UserId;
            UserLogin = user.UserLogin;
            UserPassword = user.UserPassword;
            UserEmail = user.UserEmail;
            UserCreateDate = user.UserCreateDate;
            UserLastLoginDate = user.UserLastLoginDate;
            UserActivateKey = user.UserActivateKey;
            UserIsActivated = user.UserIsActivated;
            UserIsActive = user.UserIsActive;
            Role = new HashSet<Role>();
            foreach (var role in user.Role)
            {
                Role.Add(new Role(role));
            }
        }
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserOpenID { get; set; }
        public System.DateTime UserCreateDate { get; set; }
        public System.DateTime UserLastLoginDate { get; set; }
        public string UserActivateKey { get; set; }
        public bool UserIsActivated { get; set; }
        public bool UserIsActive { get; set; }

        public virtual ICollection<Role> Role { get; set; }
    }
}
