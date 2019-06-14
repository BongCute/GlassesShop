
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlassesShop.Areas.GlassesAdmin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: GlassesAdmin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}