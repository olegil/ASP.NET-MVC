using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace UI.Security
{
    public class AccountMembershipService : IMembershipService
    {
        private CustomMembershipProvider MembershipProvider;

        public AccountMembershipService() : this(null)
        {

        }

        public AccountMembershipService(CustomMembershipProvider provider)
        {
            MembershipProvider = provider ?? new CustomMembershipProvider();
        }

        public int MinPasswordLength
        {
            get
            {
                return MembershipProvider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            return MembershipProvider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            MembershipCreateStatus status;
            MembershipProvider.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email, string OpenID)
        {
            MembershipCreateStatus status;
            MembershipProvider.CreateUser(userName, password, email, null, null, true, null, out status, OpenID);
            return status;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            MembershipUser currentUser = MembershipProvider.GetUser(userName, true);
            return currentUser.ChangePassword(oldPassword, newPassword);
        }

        public MembershipUser GetUser(string OpenID)
        {
            return MembershipProvider.GetUser(OpenID);
        }
    }
}