using BLLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace UI.Helpers
{
    public static class ViewHelper
    {
        public static bool IsInRole(string UserName, string RoleName)
        {
            string PrivilegeLevels = string.Join("", UserBLLService.GetUserRights(UserName));
            if (PrivilegeLevels.Contains(RoleName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}