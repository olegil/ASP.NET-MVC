using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLEntities
{
    public class CommentEntity
    {
        public CommentEntity()
        {

        }

        public CommentEntity(Comment comment)
        {
            CommentId = comment.CommentId;
            CommentNumber = comment.CommentNumber;
            CommentParentNumber = comment.CommentParentNumber;
            UserId = comment.UserId;
            ImageId = comment.ImageId;
            CommentText = comment.CommentText;
            CommentDate = comment.CommentDate;
        }

        public int CommentId { get; set; }
        public int CommentNumber { get; set; }
        public int CommentParentNumber { get; set; }
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public string CommentText { get; set; }
        public System.DateTime CommentDate { get; set; }

        public virtual UserEntity User { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || this.GetType() != obj.GetType())
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        CommentEntity temp = (CommentEntity)obj;
        //        if (this.CommentId != temp.CommentId)
        //        {
        //            return false;
        //        }
        //        if (this.CommentParentNumber != temp.CommentParentNumber)
        //        {
        //            return false;
        //        }
        //        if(this.UserId != temp.UserId)
        //        {
        //            return false;
        //        }
        //        if (this.ImageId != temp.ImageId)
        //        {
        //            return false;
        //        }
        //        if (this.CommentText != temp.CommentText)
        //        {
        //            return false;
        //        }
        //        if (this.CommentDate != temp.CommentDate)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
        //}
    }
}
