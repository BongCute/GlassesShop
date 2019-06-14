using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace GlassesShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductDAO().getListProductByCategory(1, 10);
            return View(model);
        }

        public ActionResult DetailProduct()
        {
            var model = new ProductDAO().getDetailProduct(3);
            ViewBag.listProductByCategory = new ProductDAO().getListProductByCategory(1, 10);
            return View(model);
        }
        public ActionResult Girls()
        {
            var model = new ProductDAO().getListProductByCategory(1, 10);
            return View(model);


        }
    }
}