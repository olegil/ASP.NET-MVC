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

        [HttpGet]
        public ViewResult ImageSummary()
        {
            //Кеширование только на клиенте, обновление при каждом запросе
            this.Response.Cache.SetCacheability(System.Web.HttpCacheability.Private);
            this.Response.Cache.SetMaxAge(TimeSpan.Zero);

            var cacheKey = "shooting-cart-" + 1;
            var cachedPair = (Tuple<DateTime, int>)this.HttpContext.Cache[cacheKey];

            if (cachedPair != null) //Если данные есть в кеше на сервере
            {
                //Устанавливаем Last-Modified
                this.Response.Cache.SetLastModified(cachedPair.Item1);

                var lastModified = DateTime.MinValue;

                //Обрабатываем Conditional Get
                if (DateTime.TryParse(this.Request.Headers["If-Modified-Since"], out lastModified) && lastModified >= cachedPair.Item1)
                {
                    return new NotModifiedResult();
                }

                ViewData["ImageCount"] = cachedPair.Item2;
            }
            else //Если данных нет в кеше на сервере
            {
                //Текущее время, округленное до секунды
                var now = DateTime.Now;
                now = new DateTime(now.Year, now.Month, now.Day,
                                    now.Hour, now.Minute, now.Second);

                //Устанавливаем Last-Modified
                this.Response.Cache.SetLastModified(now);

                var count = 1;
                this.HttpContext.Cache[cacheKey] = Tuple.Create(now, count);
                ViewData["ImageCount"] = count;
            }
            return View("ImageSummary");
        }
    }
}
