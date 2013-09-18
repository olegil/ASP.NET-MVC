using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using BLLEntities;
using BLLServices;

namespace UI.Controllers
{
    public class MyImagesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
