using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UI.SiteSettings
{
    public class SiteSettings : ConfigurationSection
    {
        [ConfigurationProperty("SearchResult", IsRequired = true)]
        public SearchResult SearchResult
        {
            get
            {
                return (SearchResult)this["SearchResult"];
            }
            set
            {
                this["SearchResult"] = value;
            }
        }

        [ConfigurationProperty("ImagesOnPage", IsRequired = true)]
        public ImagesOnPage ImagesOnPage
        {
            get
            {
                return (ImagesOnPage)this["ImagesOnPage"];
            }
            set
            {
                this["ImagesOnPage"] = value;
            }
        }
    }
}