using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlassesShop.Areas.GlassesAdmin.Assest.Common;
using GlassesShop.Areas.GlassesAdmin.Models;
using Model.DAO;
namespace GlassesShop.Areas.GlassesAdmin.Controllers
{
    public class LoginController : Controller
    {
        public string USER_SESSION { get; private set; }

        // GET: GlassesAdmin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model )
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.Name, model.password);
                if (result)
                {
                    var user = dao.GetById(model.Name);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Name;
                    userSession.UserID = user.id;
                    Session.Add(CommonConstants.USER_SESSION, userSession);              
                    return RedirectToAction("Index", "GlassesAdmin/HomeAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Login Fail!!!");
                }

            }
            return RedirectToAction("Index", "GlassesAdmin/Login");            

            /*var ListUser = new user 
            if(email.Equals("hoa@gmail.com")&&pass.Equals("123"))
            {
                return RedirectToAction("Index", "GlassesAdmin/HomeAdmin");
            }
            return RedirectToAction("Index");*/
        }
    }
}