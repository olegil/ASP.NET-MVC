﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace UI.Security
{
    public interface IMembershipService
    {
        int MinPasswordLength { get; }
        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        MembershipCreateStatus CreateUser(string userName, string password, string email, string OpenID);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
        MembershipUser GetUser(string OpenID);
    }
}