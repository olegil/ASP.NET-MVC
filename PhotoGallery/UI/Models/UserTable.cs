using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLLEntities;

namespace UI.Models
{
    public class UserTable
    {
        public UserTable()
        {
            this.Users = new List<User>();
        }

        public UserTable(IEnumerable<User> users)
        {
            this.Users = new List<User>(users);
        }

        public UserTable(IEnumerable<UserEntity> users)
        {
            this.Users = new List<User>();
            foreach (var user in users)
            {
                this.Users.Add(new User(user));
            }
        }

        public List<User> Users { get; set; }
    }
}