using BLLEntities;
using BLLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Image
    {
        public Image()
        {

        }

        public Image(ImageEntity image)
        {            
            ImageId = image.ImageId;
            UserId = image.UserId;
            UserName = UserBLLService.GetUser(UserId).UserLogin;
            ImagePicture = "data:image/png;base64," + Convert.ToBase64String(image.ImagePicture);
            Tag = new HashSet<Tag>();
            foreach (var tag in TagBLLService.GetTagsByImageId(image.ImageId))
            {
                Tag.Add(new Tag(tag));
            }
        }

        public string UserName { get; set; }
        public string ImagePicture { get; set; }
        public ICollection<Tag> Tag { get; set; }

        public int ImageId { get; set; }
        public int UserId { get; set; }
    }
}