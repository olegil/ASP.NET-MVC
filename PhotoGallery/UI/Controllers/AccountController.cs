using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using UI.Helpers;
using UI.Models;
using UI.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace UI.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        private static OpenIdRelyingParty Openid = new OpenIdRelyingParty();

        private IFormsAuthenticationService FormsService { get; set; }
        private IMembershipService MembershipService { get; set; }

        [ValidateInput(false)]
        public ActionResult Authenticate()
        {
            var Response = Openid.GetResponse();
            if (Response == null)
            {
                Identifier id;
                if (Identifier.TryParse(Request.Form["openid_identifier"], out id))
                {
                    try
                    {
                        var request = Openid.CreateRequest(Request.Form["openid_identifier"]);
                        return request.RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException)
                    {
                        return RedirectToAction("Index", "Home"); 
                    }
                }
                return RedirectToAction("Index", "Home"); 
            }
            if (Response.Status == AuthenticationStatus.Authenticated)
            {
                MembershipUser user = MembershipService.GetUser(Response.ClaimedIdentifier);
                if (user != null)
                {
                    if (user.UserName != null)
                    {
                        FormsService.SignIn(user.UserName, false);
                    }
                    else
                    {
                        return RedirectToAction("Register", "Account", new { OpenId = Response.ClaimedIdentifier });
                    }
                }
                return RedirectToAction("Index", "Home"); 
            }
            return new EmptyResult();
        }

        public ViewResult ShowRegisterForm()
        {
            return View();
        }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }
            base.Initialize(requestContext);
        }

        public ViewResult LogOn()
        {
            return View();
        }

        public ViewResult LogOnPartial(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    return View("Reload");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register(string OpenID)
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            ViewBag.OpenID = OpenID;
            return View();
        }

        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus createStatus;
                if (model.OpenID != null)
                {
                    createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.UserEmail, model.OpenID);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.UserEmail);
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        public ActionResult Activate(string username, string key)
        {
            UserRepository _user = new UserRepository();
            if (_user.ActivateUser(username, key) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("LogOn");
            }
        }

        public ActionResult SetCulture(string culture)
        {
            culture = CultureHelper.GetValidCulture(culture);
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
            {
                cookie.Value = culture;
            }
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.HttpOnly = false;
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
