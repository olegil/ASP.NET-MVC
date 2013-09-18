using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Security
{
    public interface IFormsAuthenticationService
    {
        int Timeout { get; }

        bool RequireSSL { get; }

        void SignIn(string userName, bool createPersistentCookie);

        void SignOut();
    }
}