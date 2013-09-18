using BLLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class Tag
    {
        public Tag()
        {
            
        }

        public Tag(TagEntity tag)
        {
            TagId = tag.TagId;
            TagName = tag.TagName;
        }

        public int TagId { get; set; }
        public string TagName { get; set; }
    }
}