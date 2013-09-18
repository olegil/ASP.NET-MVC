using DALEntities;
using DALInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALDatabase
{
    public class TagDAL : TagIRepository
    {
        public Tag GetTag(int TagId)
        {
            using (var DB = new DatabaseEntities())
            {
                return new Tag(DB.Tag.First(tag => tag.TagId == TagId));
            }
        }

        public IEnumerable<Tag> GetTagsByImageId(int ImageId)
        {
            using (var DB = new DatabaseEntities())
            {
                List<Tag> Result = new List<Tag>();
                var Image = DB.Image.First(image => image.ImageId == ImageId);
                foreach (var tag in DB.Tag)
                {
                    if (tag.Image.Contains(Image))
                    {
                        Result.Add(tag);
                    }
                }
                return Result;
            }
        }

        public IEnumerable<Tag> GetTagsContainsString(string SearchText)
        {
            using (var DB = new DatabaseEntities())
            {
                List<Tag> Result = new List<Tag>();
                SearchText = SearchText.ToLower();
                foreach (var tag in DB.Tag)
                {
                    if (tag.TagName.ToLower().Contains(SearchText))
                    {
                        Result.Add(tag);
                    }
                }
                return Result;
            }
        }

        public bool ContainsTag(string TagName)
        {
            using (var DB = new DatabaseEntities())
            {
                foreach (var tag in DB.Tag)
                {
                    if (tag.TagName == TagName)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void SaveTag(Tag Tag)
        {
            using (var DB = new DatabaseEntities())
            {
                DB.Tag.Add(Tag);
                DB.SaveChanges();
            }
        }
    }
}
