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
using UI.Helpers;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ImagesOnPageCount = Config.Get().ImagesOnPage.ImagesOnPageCount;
            return View();
        }

        public JsonResult FindTagsAndComments(string SearchText)
        {
            var config = Config.Get();
            var Result = AutoSuggestBLLService.GetSearchResults(SearchText, config.SearchResult.SearchResultMaxCount);
            return Json(Result);
        }

        public JsonResult FindTags(string SearchText)
        {
            var config = Config.Get();
            var Result = AutoSuggestBLLService.GetTagSearchResults(SearchText, config.SearchResult.SearchResultMaxCount);
            return Json(Result);
        }

        public ViewResult ShowSearchResult(int Id, string Name, string Type)
        {
            if (Type == "Tag")
            {
                ViewBag.TagName = Name;
                ViewBag.Id = Id;
                return View("ShowSearchResultTag", new ImageReview(ImageBLLService.GetImagesByTagId(Id)));
            }
            if (Type == "Comment")
            {
                ViewBag.CommentName = Name;
                ViewBag.Id = Id;
                return View("ShowSearchResultComment", new ImageReview(ImageBLLService.GetImagesByCommentId(Id)));
            }
            if (Type == "User")
            {
                return View("ShowSearchResultUser", UserBLLService.GetUser(Id));
            }
            var Model = new ImageReview(ImageBLLService.GetImagesBySearchName(Name));
            ViewBag.Name = Name;
            if (Model.Images.Count != 0)
            {
                return View("ShowSearchResult", Model);
            }
            else
            {
                return View("ShowSearchResult");
            }
        }        
    }
}
