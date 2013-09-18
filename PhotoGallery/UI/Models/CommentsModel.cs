using BLLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class CommentsModel
    {
        public CommentsModel()
        {
            this.Comments = new HashSet<Comment>();
        }

        public CommentsModel(Comment[] comments)
        {
            this.Comments = new HashSet<Comment>();
            foreach (var comment in comments)
            {
                this.Comments.Add(new Comment(comment));
            }
        }

        public CommentsModel(CommentEntity[] comments)
        {
            this.Comments = new HashSet<Comment>();
            foreach (var comment in comments)
            {
                this.Comments.Add(new Comment(comment));
            }
        }

        public HashSet<Comment> Comments { get; set; }
        public int ImageCount { get; set; }
    }
}