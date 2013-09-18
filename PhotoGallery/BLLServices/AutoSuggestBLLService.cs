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
    public static class AutoSuggestBLLService
    {
        public static IEnumerable<AutoSuggestEntity> GetSearchResults(string SearchText, int MaxCount)
        {
            AutoSuggestCollection Result = new AutoSuggestCollection();
            Result.MaxCount = MaxCount;
            if (SearchText.Length != 0)
            {
                Result.AddRange(Transform.TagToAutoSuggestEntity(TagBLLService.GetTagsContainsString(SearchText)));
                Result.AddRange(Transform.CommentToAutoSuggestEntity(CommentBLLService.GetCommentsContainsString(SearchText)));
            }
            return Result;
        }

        public static IEnumerable<AutoSuggestEntity> GetTagSearchResults(string SearchText, int MaxCount)
        {
            AutoSuggestCollection Result = new AutoSuggestCollection();
            Result.MaxCount = MaxCount;
            if (SearchText.Length != 0)
            {
                Result.AddRange(Transform.TagToAutoSuggestEntity(TagBLLService.GetTagsContainsString(SearchText)));
            }
            return Result;
        }
    }
}
