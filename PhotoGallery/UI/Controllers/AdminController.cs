using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLLEntities;
using BLLServices;
using UI.Models;
using UI.SiteSettings;
using UI.Helpers;

namespace UI.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult ShowUsers()
        {
            return View(new UserTable(UserBLLService.GetAllUsers()));
        }

        public ViewResult ShowChangeUserRoleForm(int UserId)
        {
            ViewBag.Roles = RoleBLLService.GetAllRoleNames();
            return View(new User(UserBLLService.GetUser(UserId)));
        }

        public JsonResult ChangeUserStatus(int UserId)
        {
            UserBLLService.ChangeUserStatus(UserId);
            return Json(true);
        }

        public JsonResult SaveRoles(string RoleNames, int UserId)
        {
            var Roles = RoleNames.Split('_');
            foreach (var role in Roles)
            {
                if (role.Length != 0)
                {
                    if (!UserBLLService.ContainsUserRole(UserId, role))
                    {
                        UserBLLService.AddUserRole(UserId, RoleBLLService.GetRoleId(role));
                    }
                }
            }
            foreach (var role in UserBLLService.GetUserRoleNames(UserId))
            {
                if (!Roles.Contains(role))
                {
                    UserBLLService.RemoveUserRole(UserId, RoleBLLService.GetRoleId(role));
                }
            }
            return Json(true);
        }

        [HttpGet]
        public ActionResult UsersCount()
        {
            //Кеширование только на клиенте, обновление при каждом запросе
            this.Response.Cache.SetCacheability(System.Web.HttpCacheability.Private);
            this.Response.Cache.SetMaxAge(TimeSpan.Zero);

            var cacheKey = "users-count-" + 1;
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

                ViewData["UsersCount"] = cachedPair.Item2;
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
                ViewData["UsersCount"] = count;
            }
            return PartialView("UsersCount");
        }
    }
}
