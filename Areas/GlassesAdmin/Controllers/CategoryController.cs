using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlassesShop.Areas.GlassesAdmin.Controllers
{
    public class CategoryController : Controller
    {
        
        // GET: GlassesAdmin/Category
        public ActionResult AddCategory()
        {
            return View();
        }
        public ActionResult EditCategory()
        {
            return View();
        }
        public ActionResult ListCategory()
        {
           
            return View();
        }
    }
}