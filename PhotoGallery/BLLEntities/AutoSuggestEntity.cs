using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLEntities
{
    public partial class AutoSuggestEntity
    {
        public AutoSuggestEntity(Tag tag)
        {
            Id = tag.TagId;
            SearchResultType = "Tag";
            SearchResultName = tag.TagName;
        }

        public AutoSuggestEntity(User user)
        {
            Id = user.UserId;
            SearchResultType = "User";
            SearchResultName = user.UserLogin;
        }

        public AutoSuggestEntity(Comment comment)
        {
            Id = comment.CommentId;
            SearchResultType = "Comment";
            SearchResultName = comment.CommentText;
        }

        public int Id { get; set; }
        public string SearchResultType { get; set; } 
        public string SearchResultName { get; set; }
    }
}
