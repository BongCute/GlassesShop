using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using System.IO;

namespace GlassesShop.Areas.GlassesAdmin.Controllers
{

    public class AdminProductController : Controller
    {
        GlassesShopDBContex db = new GlassesShopDBContex();
        // GET: GlassesAdmin/AdminProduct
        public ActionResult AddProduct()
        {
            
            var AllProduct = db.Product.ToList();
            ViewBag.AllProduct = AllProduct;

            return View();
        }
      [HttpPost]
        public ActionResult AddProduct(Product sp, HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {

                    var TenAnh = Path.GetFileName(uploadFile.FileName);
                    var Duongdan = Path.Combine(Server.MapPath("~/Assets/Client/images"), TenAnh);
                    sp.imageLink = TenAnh;
                    uploadFile.SaveAs(Duongdan);


                }
                else
                {
                    sp.imageLink = "~/Assets/Client/images/400X400.PNG";

                }
               
            }
             sp.CreateProduct = DateTime.Now;
                db.Product.Add(sp);
                db.SaveChanges();
                return RedirectToAction("ListProduct");
        }
    
        public ActionResult EditProduct(int ID_Product)
        {
            var AllProduct = db.Product.ToList();
            ViewBag.AllProduct = AllProduct;
            Product sp = db.Product.Find(ID_Product);
            sp.price = sp.price != null ? sp.price : 0;
            sp.discount = sp.discount != null ? sp.discount : 0;
            sp.Description = sp.Description != null ? sp.Description : "không có mô tả";


            return View(sp);
        }
        [HttpPost]
        public ActionResult EditProduct(Product sp,HttpPostedFileBase uploadFile)
        {
            var a = sp;
            if(uploadFile != null && uploadFile.ContentLength>0)
            {
                var TenAnh = Path.GetFileName(uploadFile.FileName);
                var Duongdan = Path.Combine(Server.MapPath(" ~/Assets/Client/images"), TenAnh);
                sp.imageLink = TenAnh;
                uploadFile.SaveAs(Duongdan);
            }
            sp.CreateProduct = DateTime.Now;
            var spCu = db.Product.Find(sp.ID_Product);
            db.Entry(spCu).CurrentValues.SetValues(sp);
             db.SaveChanges();
            return RedirectToAction("ListProduct");
        }
        [HttpPost]
        public JsonResult DeleteProduct(int ID_Product)
        {
            try
            {
                Product sp = db.Product.Find(ID_Product);
                db.Product.Remove(sp);
                db.SaveChanges();
                return Json(new { status = true });
            }
             catch (Exception ex)
            {
                return Json(new { status = false });
            }
        }
        public ActionResult ListProduct()
        {

            ViewBag.productList = db.Product.OrderByDescending(sp => sp.ID_Product).ToList();
            return View();
        }
 /*       public ActionResult Search(string Name )
        {
            List<Product> lstProduct = db.Products.Where(x => x.Name.Contains(Name)).ToList();
        }*/
    }
}