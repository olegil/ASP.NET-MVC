using BLLEntities;
using BLLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class ImageViewController : Controller
    {
        public JsonResult GetImageId(FormCollection form)
        {
            string ImageIndex = form["ImageIndex"];
            return Json(ImageBLLService.GetImageIds(Convert.ToInt32(ImageIndex), 1).ToArray()[0]);
        }

        public JsonResult SetImageIndexByImageId(int ImageId)
        {
            return Json(ImageBLLService.GetImageIndexByImageId(ImageId));
        }

        public ViewResult GetImage(int ImageId)
        {
            return View(new Image(ImageBLLService.GetImage(ImageId)));
        }

        public ViewResult GetComments(int ImageId, string CommentNumber)
        {
            CommentsModel Model = null;
            if (CommentNumber != "")
            {
                int Number = Convert.ToInt32(CommentNumber);
                var NewComments = CommentBLLService.GetNewImageComments(ImageId, Number);
                Model = new CommentsModel(NewComments.ToArray());
            }
            else
            {
                var FirstComments = CommentBLLService.GetAllImageComments(ImageId);
                Model = new CommentsModel(FirstComments);
            }
            return View(Model);
        }

        public ViewResult PostComment(int ImageIndex, string CommentText)
        {
            int ImageId = ImageBLLService.GetImageIds(ImageIndex, 1).ToArray()[0];
            int UserId = UserBLLService.GetUserIdByLogin(HttpContext.User.Identity.Name);
            CommentBLLService.SaveComment(DateTime.UtcNow, CommentText, UserId, ImageId);
            return View();
        }
    }
}
