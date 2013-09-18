using BLLEntities;
using BLLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public partial class Comment
    {
        public Comment()
        {

        }

        public Comment(Comment comment)
        {
            CommentId = comment.CommentId;
            CommentNumber = comment.CommentNumber;
            CommentParentNumber = comment.CommentParentNumber;
            UserName = comment.UserName;
            CommentText = comment.CommentText;
            CommentDate = comment.CommentDate;
            ImageId = comment.ImageId;
            UserId = comment.UserId;
        }

        public Comment(CommentEntity comment)
        {
            CommentId = comment.CommentId;
            CommentNumber = comment.CommentNumber;
            CommentParentNumber = comment.CommentParentNumber;
            UserName = UserBLLService.GetUser(comment.UserId).UserLogin;
            CommentText = comment.CommentText;
            CommentDate = comment.CommentDate;
            ImageId = comment.ImageId;
            UserId = comment.UserId;
        }

        public int CommentId { get; set; }
        public int CommentNumber { get; set; }
        public int CommentParentNumber { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public System.DateTime CommentDate { get; set; }

        public int ImageId { get; set; }
        public int UserId { get; set; }
    }
}