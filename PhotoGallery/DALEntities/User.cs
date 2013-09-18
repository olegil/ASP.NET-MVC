//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Comment = new HashSet<Comment>();
            this.Image = new HashSet<Image>();
            this.Role = new HashSet<Role>();
        }

        public User(User user)
        {
            UserId = user.UserId;
            UserLogin = user.UserLogin;
            UserPassword = user.UserPassword;
            UserEmail = user.UserEmail;
            UserOpenID = user.UserOpenID;
            UserCreateDate = user.UserCreateDate;
            UserLastLoginDate = user.UserLastLoginDate;
            UserActivateKey = user.UserActivateKey;
            UserIsActivated = user.UserIsActivated;
            UserIsActive = user.UserIsActive;
            this.Role = new HashSet<Role>();
            foreach (var role in user.Role)
            {
                Role.Add(new Role(role));
            }
            this.Comment = new HashSet<Comment>();
            foreach (var comment in user.Comment)
            {
                Comment.Add(new Comment(comment));
            }
            this.Image = new HashSet<Image>();
            foreach (var image in user.Image)
            {
                Image.Add(new Image(image));
            }
        }
    
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserOpenID { get; set; }
        public System.DateTime UserCreateDate { get; set; }
        public System.DateTime UserLastLoginDate { get; set; }
        public bool UserIsActivated { get; set; }
        public bool UserIsActive { get; set; }
        public string UserActivateKey { get; set; }
    
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<Role> Role { get; set; }
    }
}