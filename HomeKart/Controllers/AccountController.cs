using HomeKartBL;
using HomeKartEntity;
using System;
using HomeKart.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using HomeKartDAL;

namespace HomeKart.Controllers
{
    public class AccountController : Controller
    {
        UserBusinessLogic userManager;
        public AccountController()
        {
            userManager = new UserBusinessLogic();
        }
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountModel userLoginData)
        {
            User login = Mapper.Map<AccountModel, User>(userLoginData);
            User user = userManager.CheckLogin(login);
            if (user != null)
            {
                User ValidatedUser = userManager.CheckLogin(login);
                FormsAuthentication.SetAuthCookie(ValidatedUser.Email, false);
                var authTicket = new FormsAuthenticationTicket(1, ValidatedUser.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, ValidatedUser.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                if (ValidatedUser.Role == "admin")
                {
                    Session["Email"] = ValidatedUser.Role;
                    Session["UserId"] = ValidatedUser.UserId;
                    TempData["Message"] = ValidatedUser.Role;
                    return RedirectToAction("UserDashBoard");
                }
                else if (ValidatedUser.Role != null)
                {
                    Session["Email"] = ValidatedUser.Role;
                    Session["UserId"] = ValidatedUser.UserId;
                    TempData["Message"] = ValidatedUser.Role;
                    return RedirectToAction("UserDashBoard");
                }
            }
            else
                TempData["Message"] = "Incorrect UserName or Password";
            return View();
        }
        [Authorize]
        public ActionResult Secured()
        {
            return View();
        }
        public ActionResult UserDashBoard()
        {
            if (Session["Email"] != null)
            {
                if (Session["Email"].ToString() == "admin")
                {
                    return RedirectToAction("AdminHome", "Admin");
                }
                else if (Session["Email"].ToString() != null)
                {

                    return RedirectToAction("CustomerHome", "Customer");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult LogOut()
        {
            Session.Remove("UserName");
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Registration(AccountModel userdata)
        {
            
            if (ModelState.IsValid)
            {
                User registration = Mapper.Map<AccountModel, User>(userdata);
                var keyNew = Helper.GeneratePassword(10);
                var password = Helper.EncodePassword(registration.Password, keyNew);
                registration.Password = password;
                registration.HashCode = keyNew;
                registration.Role = Role.user.ToString();
                if (userManager.ToRegister(registration) == true)
                    TempData["Message"] = "Registered Sucessfully";
                return RedirectToAction("Secured", "Account");
            }
            TempData["Message"] = "Try Again";
            return View();
        }
    }

}