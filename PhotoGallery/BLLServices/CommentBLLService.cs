using BLLEntities;
using BLLTransform;
using BLLCommentService;
using DALEntities;
using DALFactory;
using DALInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLServices
{
    public static class CommentBLLService
    {
        public static CommentEntity GetComment(int CommentId)
        {
            CommentIRepository CommentRepository = RepositoryFactory.GetCommentRepository();
            return new CommentEntity(CommentRepository.GetComment(CommentId));
        }

        public static CommentEntity[] GetNewImageComments(int ImageId, int LastCommentNumber)
        {
            return CommentSearcher.SelectNewComments(GetAllImageComments(ImageId), LastCommentNumber);
        }

        public static CommentEntity[] GetAllImageComments(int ImageId)
        {
            CommentIRepository CommentRepository = RepositoryFactory.GetCommentRepository();
            return Transform.CommentToCommentEntity(CommentRepository.GetAllImageComments(ImageId));
        }

        public static CommentEntity[] SaveComment(DateTime CommentDate, string CommentText, int UserId, int ImageId)
        {            
            var Comments = CommentParser.BuildComments(CommentDate, CommentText, UserId, ImageId);
            foreach (var comment in Comments)
            {
                comment.CommentNumber = GetCommentNumber(ImageId);
                SaveComment(comment);
            }
            return Comments;
        }

        private static int GetCommentNumber(int ImageId)
        {
            CommentIRepository CommentRepository = RepositoryFactory.GetCommentRepository();
            return CommentRepository.GetCommentNumber(ImageId);
        }

        private static void SaveComment(CommentEntity comment)
        {
            CommentIRepository CommentRepository = RepositoryFactory.GetCommentRepository();
            CommentRepository.SaveComment(new Comment 
            {
                CommentId = comment.CommentId,
                CommentDate = comment.CommentDate,
                CommentNumber = comment.CommentNumber,
                CommentParentNumber = comment.CommentParentNumber,
                CommentText = comment.CommentText,
                UserId = comment.UserId,
                ImageId = comment.ImageId
            });
        }

        internal static IEnumerable<Comment> GetCommentsContainsString(string SearchText)
        {
            CommentIRepository CommentRepository = RepositoryFactory.GetCommentRepository();
            return CommentRepository.GetCommentsContainsString(SearchText);
        }

        public static void RemoveCommentsByImageId(int ImageId)
        {
            CommentIRepository CommentRepository = RepositoryFactory.GetCommentRepository();
            CommentRepository.RemoveCommentsByImageId(ImageId);
        }
    }
}
