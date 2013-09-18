using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UI.SiteSettings
{
    public class SearchResult : ConfigurationElement
    {
        [ConfigurationProperty("SearchResultMaxCount", DefaultValue = 5, IsRequired = true)]
        [IntegerValidator(MinValue = 1, MaxValue = 15)]
        public int SearchResultMaxCount
        {
            get
            {
                return (int)this["SearchResultMaxCount"];
            }
            set
            {
                this["SearchResultMaxCount"] = value;
            }
        }
    }
}