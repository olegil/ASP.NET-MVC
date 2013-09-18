using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterface
{
    public interface CommentIRepository
    {
        Comment GetComment(int CommentId);
        Comment[] GetAllImageComments(int ImageId);
        int GetCommentNumber(int ImageId);
        void SaveComment(Comment comment);
        IEnumerable<Comment> GetCommentsContainsString(string SearchText);
        void RemoveCommentsByImageId(int ImageId);
    }
}
