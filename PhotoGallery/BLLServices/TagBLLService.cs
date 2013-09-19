using BLLEntities;
using BLLTransform;
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
    public static class TagBLLService
    {
        public static void SaveTag(TagEntity Tag)
        {
            TagIRepository TagRepository = RepositoryFactory.GetTagRepository();
            TagRepository.SaveTag(new Tag { TagName = Tag.TagName, Image = new HashSet<Image>() });
        }

        public static bool ContainsTag(string TagName)
        {
            TagIRepository TagRepository = RepositoryFactory.GetTagRepository();
            return TagRepository.ContainsTag(TagName);
        }

        public static int GetTagId(string TagName)
        {
            TagIRepository TagRepository = RepositoryFactory.GetTagRepository();
            return TagRepository.GetTagId(TagName);
        }

        public static IEnumerable<TagEntity> GetTagsByImageId(int ImageId)
        {
            TagIRepository TagRepository = RepositoryFactory.GetTagRepository();
            return Transform.TagToTagEntity(TagRepository.GetTagsByImageId(ImageId).ToArray());
        }

        public static IEnumerable<Tag> GetTagsContainsString(string SearchText)
        {
            TagIRepository TagRepository = RepositoryFactory.GetTagRepository();
            return TagRepository.GetTagsContainsString(SearchText);
        }
    }
}
