using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Net.Mail;
using BLLServices;
using BLLEntities;
using System.Net;
using UI.Models;

namespace UI.Security
{
    public class UserRepository
    {
        public MembershipUser CreateUser(string username, string password, string email, string OpenID = null)
        {
            User user = new User();
            user.UserLogin = username;
            user.UserEmail = email;
            user.UserPassword = password;
            user.UserOpenID = OpenID;
            user.UserCreateDate = DateTime.Now;
            user.UserLastLoginDate = DateTime.Now;
            user.UserActivateKey = GenerateKey();
            user.Role = new HashSet<Role>();
            user.UserIsActive = true;
            UserBLLService.SaveUser(new UserEntity
            {
                UserLogin = user.UserLogin,
                UserEmail = user.UserEmail,
                UserOpenID = user.UserOpenID,
                UserPassword = user.UserPassword,
                UserCreateDate = user.UserCreateDate,
                UserLastLoginDate = user.UserLastLoginDate,
                UserActivateKey = user.UserActivateKey,
                UserIsActive = user.UserIsActive,
                Role = new HashSet<RoleEntity>(),
                Comment = new HashSet<CommentEntity>(),
                Image = new HashSet<ImageEntity>()
            });
            UserBLLService.AddUserRole(UserBLLService.GetUserIdByLogin(user.UserLogin), 1);
            string ActivationLink = "http://localhost:1079/Account/Activate/" + user.UserLogin + "/" + user.UserActivateKey;
            SendEmailThroughGmail(ActivationLink, user.UserEmail);
            return GetUser(username);
        }

        private static void SendEmailThroughGmail(string messageBody, string emailTo)
        {
            //SmtpClient client = new SmtpClient();
            //NetworkCredential basicAuthenticationInfo = new NetworkCredential("nickolay.sivokho@gmail.com", "ybrjkfq23cbdj[j");
            //client.Host = "smtp.gmail.com";
            //client.UseDefaultCredentials = false;
            //client.Credentials = basicAuthenticationInfo;
            //client.EnableSsl = true;

            //MailAddress to = new MailAddress(emailTo);
            //MailAddress from = new MailAddress("nickolay.sivokho@gmail.com", "Account activation", System.Text.Encoding.UTF8);

            //MailMessage message = new MailMessage(from, to);
            //message.Body = messageBody;
            //message.IsBodyHtml = true;
            //message.BodyEncoding = System.Text.Encoding.UTF8;
            //message.Subject = "Account activation";
            //message.SubjectEncoding = System.Text.Encoding.UTF8;

            //client.Send(message);
        }


        public bool ActivateUser(string username, string key)
        {
            var dbuser = UserBLLService.GetUserByLogin(username);
            if (dbuser.UserActivateKey == key)
            {
                UserBLLService.ActivateUser(dbuser.UserId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateUser(string username, string password)
        {
            var dbuser = UserBLLService.GetUserByLogin(username);
            if (dbuser.UserPassword == dbuser.UserPassword && dbuser.UserIsActivated == true)
                return true;
            else
                return false;
        }

        public string GetUserNameByEmail(string email)
        {
            var dbuser = UserBLLService.GetUserByEmail(email);
            if (dbuser.UserLogin == null)
                return "";
            return dbuser.UserLogin;
        }

        public MembershipUser GetUser(string username)
        {
            var dbuser = UserBLLService.GetUserByLogin(username);
            if (dbuser.UserId == 0)
            {
                dbuser = UserBLLService.GetUserByOpenID(username);
            }
            string _username = dbuser.UserLogin;
            int _providerUserKey = dbuser.UserId;
            string _email = dbuser.UserEmail;
            string _passwordQuestion = "";
            bool _isApproved = dbuser.UserIsActivated;
            DateTime _creationDate = dbuser.UserCreateDate;
            DateTime _lastLoginDate = dbuser.UserLastLoginDate;
            DateTime _lastActivityDate = DateTime.Now;
            DateTime _lastPasswordChangedDate = DateTime.Now;
            MembershipUser user = new MembershipUser("CustomMembershipProvider",
                                                      _username,
                                                      _providerUserKey,
                                                      _email,
                                                      _passwordQuestion,
                                                      "",
                                                      _isApproved,
                                                      false,
                                                      _creationDate,
                                                      _lastLoginDate,
                                                      _lastActivityDate,
                                                      _lastPasswordChangedDate,
                                                      _creationDate);
            return user;
        }

        private static string GenerateKey()
        {
            Guid emailKey = Guid.NewGuid();
            return emailKey.ToString();
        }

    }
}