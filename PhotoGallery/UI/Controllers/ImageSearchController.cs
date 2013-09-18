using BLLServices;
using BLLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using UI.Helpers;
using System.Web.UI;
using UI.SiteSettings;

namespace UI.Controllers
{
    public class ImageSearchController : Controller
    {
        public ViewResult GetPageButtons()
        {
            ViewBag.ImageCount = ImageBLLService.GetAllImagesCount();
            ViewBag.PageCount = GetPageCount(ViewBag.ImageCount);
            return View();
        }

        public ViewResult GetSearchPageButtons(int Count)
        {
            ViewBag.ImageCount = Count;
            ViewBag.PageCount = GetPageCount(Count);
            return View("GetPageButtons");
        }

        public ViewResult GetImageTable(int StartIndex)
        {
            return View();
        }

        //[OutputCache(Location=OutputCacheLocation.Any, Duration=30000)]
        //public ViewResult GetImageReview(int StartIndex)
        //{
        //    var Count = Config.Get().ImagesOnPage.ImagesOnPageCount;
        //    this.Response.Cache.SetCacheability(System.Web.HttpCacheability.Private);
        //    this.Response.Cache.SetMaxAge(TimeSpan.Zero);
        //    ImageReview Model = null;
        //    var cacheKey = "images-" + Count + StartIndex;
        //    var cachedPair = (Tuple<DateTime, int>)this.HttpContext.Cache[cacheKey];
        //    if (cachedPair != null)
        //    {
        //        this.Response.Cache.SetLastModified(cachedPair.Item1);
        //        var lastModified = DateTime.MinValue;
        //        if (IsCached(cachedPair.Item1))
        //        {
        //            return new NotModifiedResult();
        //        }                
        //        Model = new ImageReview(ImageBLLService.GetImages((cachedPair.Item2 % 10), (cachedPair.Item2 / 10)));
        //    }
        //    else
        //    {
        //        var Now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        //        this.Response.Cache.SetLastModified(Now);                
        //        this.HttpContext.Cache[cacheKey] = Tuple.Create(Now, (Count * 10 + StartIndex));
        //        Model = new ImageReview(ImageBLLService.GetImages(StartIndex, Count));
        //    }
        //    return View(Model);
        //}

        //private bool IsCached(DateTime ContentModified)
        //{
        //    string Header = Request.Headers["If-Modified-Since"];
        //    if (Header != null)
        //    {
        //        DateTime LastModified;
        //        if (DateTime.TryParse(Header, out LastModified))
        //        {
        //            return LastModified > ContentModified;
        //        }
        //    }
        //    return false;
        //}

        public ViewResult GetImageReview(int StartIndex)
        {
            ImageReview Model = new ImageReview(ImageBLLService.GetImages(StartIndex, Config.Get().ImagesOnPage.ImagesOnPageCount));
            return View(Model);
        }

        public ViewResult GetTagImageReview(int StartIndex, int Id)
        {
            ImageReview Model = new ImageReview(ImageBLLService.GetImagesByTagId(Id, StartIndex, Config.Get().ImagesOnPage.ImagesOnPageCount));
            return View("GetImageReview", Model);
        }

        public ViewResult GetCommentImageReview(int StartIndex, int Id)
        {
            ImageReview Model = new ImageReview(ImageBLLService.GetImagesByCommentId(Id, StartIndex, Config.Get().ImagesOnPage.ImagesOnPageCount));
            return View("GetImageReview", Model);
        }

        public ViewResult GetItemImageReview(int StartIndex, string Name)
        {
            ImageReview Model = new ImageReview(ImageBLLService.GetImagesBySearchName(Name, StartIndex, Config.Get().ImagesOnPage.ImagesOnPageCount));
            return View("GetImageReview", Model);
        }

        private int GetPageCount(int ImageCount)
        {
            var Count = Config.Get().ImagesOnPage.ImagesOnPageCount;
            if ((ImageCount % Count) == 0)
            {
                return (ImageCount / Count);
            }
            return ((ImageCount / Count) + 1);
        }
    }
}
