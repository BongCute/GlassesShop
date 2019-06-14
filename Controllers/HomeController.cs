using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace GlassesShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.listPromotionProduct = new PromotionDAO().getAll(1);
            ViewBag.listProductHot = new ProductDAO().getListProductByHot(10);
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Category()
        {
            var model = new CategoryDAO().getAll();
            return PartialView(model);
        }
    }
}