using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class RegisterModel
    {
        [Display(Name = "OpenID")]
        public string OpenID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "UserNameRequired")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailRequired")]
        public string UserEmail { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PasswordShouldConsist")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PasswordRequestRequired")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PasswordAndRequestAreNotEqual")]
        public string ConfirmPassword { get; set; }
    }
}