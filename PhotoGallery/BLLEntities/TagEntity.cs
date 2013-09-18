using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLEntities
{
    public partial class TagEntity
    {
        public TagEntity()
        {
            this.Image = new HashSet<ImageEntity>();
        }

        public TagEntity(Tag tag)
        {
            TagId = tag.TagId;
            TagName = tag.TagName;
            this.Image = new HashSet<ImageEntity>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<ImageEntity> Image { get; set; }
    }
}
