using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLEntities
{
    public class ImageEntity
    {
        public ImageEntity()
        {
            this.Comment = new HashSet<CommentEntity>();
            this.Tag = new HashSet<TagEntity>();
        }

        public ImageEntity(Image image)
        {
            ImageId = image.ImageId;
            UserId = image.UserId;
            ImagePicture = image.ImagePicture;
            this.Comment = new HashSet<CommentEntity>();
            this.Tag = new HashSet<TagEntity>();
        }

        public int ImageId { get; set; }
        public int UserId { get; set; }
        public byte[] ImagePicture { get; set; }

        public virtual ICollection<CommentEntity> Comment { get; set; }
        public virtual ICollection<TagEntity> Tag { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
