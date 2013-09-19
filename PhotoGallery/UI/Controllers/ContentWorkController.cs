using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using System.IO;
using System.Web.Helpers;
using BLLEntities;
using BLLServices;
using System.Web.UI;
using UI.SiteSettings;

namespace UI.Controllers
{
    public class ContentWorkController : Controller
    {
        public ViewResult ShowAddPhotoForm()
        {
            return View();
        }

        public ViewResult ShowAddTagForm()
        {
            return View();
        }

        public ViewResult ShowChangeTagForm(int ImageId)
        {
            return View(new Image(ImageBLLService.GetImage(ImageId)));
        }

        public ViewResult ShowRemovePhotoForm(int ImageId)
        {
            ViewBag.ImageId = ImageId;
            return View();
        }

        public ViewResult UploadImage(HttpPostedFileBase[] files)
        {
            return View("ShowUploadImages", HttpPostedFileBaseToString(files));
        }

        public JsonResult SaveImage(HttpPostedFileBase[] files, string TagNames)
        {
            var ImagesContent = HttpPostedFileBaseToByte(files);
            var TagData = TagNames.Split('_');
            var Tags = new HashSet<TagEntity>();
            for (int i = 0; i < TagData.Length; i++)
            {
                if (TagData[i].Length != 0)
                {
                    Tags.Add(new TagEntity { TagId = Convert.ToInt32(TagData[i++]), TagName = TagData[i] });
                }
            }
            foreach (var image in ImagesContent)
            {
                ImageEntity Image = new ImageEntity { UserId = UserBLLService.GetUserIdByLogin(HttpContext.User.Identity.Name), Comment = new HashSet<CommentEntity>(), Tag = Tags, ImagePicture = image };
                ImageBLLService.SaveImage(Image);
            }
            return Json(true);
        }

        public JsonResult RemoveImage(int Id)
        {
            ImageBLLService.RemoveImage(Id);
            return Json(true);
        }

        public JsonResult SaveTags(string TagNames)
        {
            foreach (var tag in TagNames.Split('_'))
            {
                if (!TagBLLService.ContainsTag(tag))
                {
                    TagBLLService.SaveTag(new TagEntity { TagName = tag, Image = new HashSet<ImageEntity>() });
                }
            }
            return Json(true);
        }

        public JsonResult ChangeTags(string TagNames, int ImageId)
        {
            var Tags = TagNames.Split('_');
            foreach (var tag in Tags)
            {
                if (tag.Length != 0)
                {
                    if (!ImageBLLService.ContainsImageTag(ImageId, tag))
                    {
                        ImageBLLService.AddImageTag(ImageId, TagBLLService.GetTagId(tag));
                    }
                }
            }
            foreach (var tag in ImageBLLService.GetImageTagNames(ImageId))
            {
                if (!Tags.Contains(tag))
                {
                    ImageBLLService.RemoveImageTag(ImageId, TagBLLService.GetTagId(tag));
                }
            }
            return Json(true);
        }

        private IEnumerable<byte[]> HttpPostedFileBaseToByte(HttpPostedFileBase[] files)
        {
            HashSet<byte[]> Images = new HashSet<byte[]>();
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file != null)
                    {
                        MemoryStream Stream = new MemoryStream();
                        file.InputStream.CopyTo(Stream);
                        Images.Add(Stream.GetBuffer());
                    }
                }
            }
            return Images;
        }

        private IEnumerable<string> HttpPostedFileBaseToString(HttpPostedFileBase[] files)
        {
            List<string> Files = new List<string>();
            foreach (var image in HttpPostedFileBaseToByte(files))
            {
                Files.Add("data:image/png;base64," + Convert.ToBase64String(image));
            }
            return Files;
        }
    }
}
