using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLLEntities;
using BLLServices;
using UI.Models;
using UI.SiteSettings;

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
    }
}
