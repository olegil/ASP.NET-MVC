using BLLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLCommentService
{
    public static class CommentSearcher
    {
        public static CommentEntity[] SelectNewComments(CommentEntity[] Comments, int LastCommentNumber)
        {
            List<CommentEntity> Result = new List<CommentEntity>();
            foreach (var comment in Comments)
            {
                if (comment.CommentNumber > LastCommentNumber)
                {
                    Result.Add(comment);
                }
            }
            return Result.ToArray();
        }
    }
}
