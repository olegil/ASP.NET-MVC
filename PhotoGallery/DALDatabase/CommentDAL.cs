using DALEntities;
using DALInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALDatabase
{
    public class CommentDAL : CommentIRepository
    {
        public Comment GetComment(int CommentId)
        {
            using (var DB = new DatabaseEntities())
            {
                return new Comment(DB.Comment.ToArray().First(comment => comment.CommentId == CommentId));
            }  
        }

        public Comment[] GetAllImageComments(int ImageId)
        {
            using (var DB = new DatabaseEntities())
            {
                return DB.Comment.Where(comment => comment.ImageId == ImageId).ToArray();
            }
        }

        public int GetCommentNumber(int ImageId)
        {
            using (var DB = new DatabaseEntities())
            {
                if(DB.Comment.Where(comment => comment.ImageId == ImageId).Count() == 0)
                {
                    return 1;
                }
                int Number = 0;
                Number = DB.Comment.Where(comment => comment.ImageId == ImageId).Max(com => com.CommentNumber);
                return ++Number;
            }
        }

        public void SaveComment(Comment comment)
        {
            using (var DB = new DatabaseEntities())
            {
                DB.Comment.Add(comment);
                DB.SaveChanges();
            }
        }

        public IEnumerable<Comment> GetCommentsContainsString(string SearchText)
        {
            using (var DB = new DatabaseEntities())
            {
                List<Comment> Result = new List<Comment>();
                SearchText = SearchText.ToLower();
                foreach (var comment in DB.Comment)
                {
                    if (comment.CommentText.ToLower().Contains(SearchText))
                    {
                        Result.Add(comment);
                    }
                }
                return Result;
            }
        }

        public void RemoveCommentsByImageId(int ImageId)
        {
            using (var DB = new DatabaseEntities())
            {
                foreach (var comment in DB.Comment)
                {
                    if (comment.ImageId == ImageId)
                    {
                        DB.Comment.Remove(comment);
                    }
                }
            }
        }
    }
}
