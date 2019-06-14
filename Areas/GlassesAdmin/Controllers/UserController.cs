using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlassesShop.Areas.GlassesAdmin.Controllers
{
    public class UserController : Controller
    {
        // GET: GlassesAdmin/User

        GlassesShopDBContex db = new GlassesShopDBContex();
        public ActionResult AddUser( User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();

                /*var encryptedMd5Pas = Encryptor.MD5Hash(user.password);
                user.password = encryptedMd5Pas;*/

                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Add User Success");
                }
              }
            return View();
        }

        public ActionResult ListUser()
        {
            return View();
        }

        public ActionResult EditUser()
        {
            

            return View();
        }
    }

    internal class Encryptor
    {
        internal static object MD5Hash(string password)
        {
            throw new NotImplementedException();
        }
    }
}