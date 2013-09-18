using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UI.SiteSettings
{
    public class Config
    {
        internal Config() { }

        private const string CONFIGGROUPNAME = "SiteSettingsGroup/";
        private const string CONFIGSECTIONNAME = "SiteSettings";

        internal static SiteSettings Get()
        {
            var config = (SiteSettings)ConfigurationManager.GetSection(String.Concat(CONFIGGROUPNAME, CONFIGSECTIONNAME));
            return config;
        }
    }
}