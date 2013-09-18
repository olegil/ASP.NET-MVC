using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class LogOnModel
    {
        [Display(Name = "OpenID")]
        public string OpenID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "UserNameRequired")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}