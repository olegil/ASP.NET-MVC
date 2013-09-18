using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UI.SiteSettings
{
    public class ImagesOnPage : ConfigurationElement
    {
        [ConfigurationProperty("ImagesOnPageCount", DefaultValue = 8, IsRequired = true)]
        [IntegerValidator(MinValue = 1, MaxValue = 10)]
        public int ImagesOnPageCount
        {
            get
            {
                return (int)this["ImagesOnPageCount"];
            }
            set
            {
                this["ImagesOnPageCount"] = value;
            }
        }
    }
}