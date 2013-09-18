using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterface
{
    public interface TagIRepository
    {
        Tag GetTag(int TagId);
        IEnumerable<Tag> GetTagsByImageId(int ImageId);
        IEnumerable<Tag> GetTagsContainsString(string SearchText);
        bool ContainsTag(string TagName);
        void SaveTag(Tag Tag);
    }
}
