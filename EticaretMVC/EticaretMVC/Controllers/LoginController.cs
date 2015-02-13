using EticaretMVC.Models.DTO;
using EticaretMVC.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace EticaretMVC.Controllers
{
  
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                UserService us = new UserService();
                us.Save1(user);
                return RedirectToAction("Account", "Login");
            }
            else
                return View();
        }
        [HttpGet]
        public ActionResult Account()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Account(UserDTO user)
        {
            UserService us = new UserService();
            var users=us.GetUserData(user);
            if (users !=null)
            {
             FormsAuthentication.SetAuthCookie(user.UserName,false);
             Session["_user"] = us.GetUserData(user);
                return RedirectToAction("Index","Home");
         
               
  
            }

                else
                {
                    ModelState.AddModelError("", "Login Gerçekleşmedi");
                }
             return View(user);
            }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["_user"] = null;
            return RedirectToAction("Index", "Home");
        }
        }
    }

