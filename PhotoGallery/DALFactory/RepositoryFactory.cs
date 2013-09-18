using DALDatabase;
using DALInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    public static class RepositoryFactory
    {
        public static CommentIRepository GetCommentRepository()
        {
            return new CommentDAL();
        }

        public static ImageIRepository GetImageRepository()
        {
            return new ImageDAL();
        }

        public static RoleIRepository GetRoleRepository()
        {
            return new RoleDAL();
        }

        public static TagIRepository GetTagRepository()
        {
            return new TagDAL();
        }

        public static UserIRepository GetUserRepository()
        {
            return new UserDAL();
        }        
    }
}
