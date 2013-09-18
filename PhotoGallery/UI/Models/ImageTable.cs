using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLLEntities;

namespace UI.Models
{
    public class ImageTable
    {
        public ImageTable()
        {
            this.Images = new List<Image>();
        }

        public ImageTable(IEnumerable<Image> images)
        {
            this.Images = new List<Image>(images);
        }

        public ImageTable(IEnumerable<ImageEntity> images)
        {
            this.Images = new List<Image>();
            foreach (var image in images)
            {
                this.Images.Add(new Image(image));
            }
        }

        public List<Image> Images { get; set; }
    }
}