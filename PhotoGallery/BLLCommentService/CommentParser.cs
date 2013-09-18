using BLLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLCommentService
{
    public static class CommentParser
    {
        public static CommentEntity[] BuildComments(DateTime CommentDate, string CommentText, int UserId, int ImageId)
        {
            CommentEntity[] Result = null;
            List<int> ParentNumbers = new List<int>();
            List<string> ParentReferences = new List<string>();
            int i = 0;
            for (i = 0; i < CommentText.Length; i++)
            {
                if (CommentText[i] == '>' && CommentText[i + 1] == '>')
                {
                    int j = 0;
                    for (j = i +2 ; CommentText[j] != '\n'; j++) ;
                    ParentReferences.Add(CommentText.Substring(i, j - i + 1));                 
                    int Id = 0;
                    int.TryParse(CommentText.Substring(i, j - i).Remove(0, 2), out Id);
                    ParentNumbers.Add(Id);
                    i += (ParentReferences.Last().Count() - 1);
                    if (i >= CommentText.Length)
                    {
                        break;
                    }
                }
            }
            if (ParentNumbers.Count() == 0)
            {
                Result = new CommentEntity[1];
                Result[0] = new CommentEntity 
                {
                    CommentDate = CommentDate,
                    CommentParentNumber = 0,
                    CommentText = CommentText, 
                    ImageId = ImageId,
                    UserId = UserId
                };
                return Result;
            }
            foreach (var item in ParentReferences)
            {
                CommentText = CommentText.Replace(item, "");
            }
            if (CommentText == "")
            {
                Result = new CommentEntity[0];
                return Result;
            }
            Result = new CommentEntity[ParentNumbers.Count()];
            for (i = 0; i < ParentNumbers.Count(); i++)
            {
                Result[i] = new CommentEntity 
                { 
                    CommentDate = CommentDate,
                    CommentParentNumber = ParentNumbers[i],
                    CommentText = CommentText,
                    ImageId = ImageId, 
                    UserId = UserId 
                };
            }
            return Result;
        }
    }
}
