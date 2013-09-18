using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLEntities
{
    public class UserEntity
    {
        public UserEntity()
        {
            this.Role = new HashSet<RoleEntity>();
            this.Image = new HashSet<ImageEntity>();
            this.Role = new HashSet<RoleEntity>();
        }

        public UserEntity(User user)
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
            this.Role = new HashSet<RoleEntity>();
            foreach (var role in user.Role)
            {
                Role.Add(new RoleEntity(role));
            }
            this.Comment = new HashSet<CommentEntity>();
            foreach (var comment in user.Comment)
            {
                Comment.Add(new CommentEntity(comment));
            }
            this.Image = new HashSet<ImageEntity>();
            foreach (var image in user.Image)
            {
                Image.Add(new ImageEntity(image));
            }
        }

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                var hasRole = Role.Any(p => string.Compare(p.RoleName, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
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

        public virtual ICollection<CommentEntity> Comment { get; set; }
        public virtual ICollection<ImageEntity> Image { get; set; }
        public virtual ICollection<RoleEntity> Role { get; set; }
    }
}
