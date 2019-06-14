using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using System.IO;

namespace GlassesShop.Areas.GlassesAdmin.Controllers
{
    public class InvoiceController : Controller
    {
        GlassesShopDBContex db = new GlassesShopDBContex();
        // GET: GlassesAdmin/Invoice
        public ActionResult ListInvoice()
        {
                ViewBag.InvoiceList = db.Invoice.OrderByDescending(hd => hd.ID_Invoice).ToList();
                return View();
        }

    }
}