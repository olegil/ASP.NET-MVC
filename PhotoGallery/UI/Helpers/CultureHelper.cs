using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Helpers
{
    public static class CultureHelper
    {
        private static readonly List<string> Cultures = new List<string> {
            "ru-RU", 
            "en-US",
        };

        public static string GetValidCulture(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Cultures.ElementAt(0);
            }
            if (Cultures.Contains(name))
            {
                return name;
            }
            foreach (var c in Cultures)
                if (c.StartsWith(name.Substring(0, 2)))
                {
                    return c;
                }
            return Cultures.ElementAt(0); 
        }

        public static string GetCultureFromCookies(HttpRequest request)
        {
            string cultureName = null;
            HttpCookie cultureCookie = request.Cookies["_culture"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                if (request.UserLanguages != null)
                {
                    cultureName = request.UserLanguages[0];
                }
            }
            return GetValidCulture(cultureName); 
        }
    }
}