using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace UI.Security
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        private HttpContextBase httpContext;

        public int Timeout
        {
            get 
            {
                return FormsAuthentication.Timeout.Minutes;
            }
        }

        public bool RequireSSL
        {
            get 
            {
                return FormsAuthentication.RequireSSL;
            }
        }

        public FormsAuthenticationService() : this(new HttpContextWrapper(HttpContext.Current))
        {

        }

        public FormsAuthenticationService(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            this.httpContext = httpContext;
        }

        public void SignIn(string userName, bool createPersistentCookie)
        {          
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);           
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public void RedirectToSignIn()
        {
            throw new NotImplementedException();
        }
    }
}