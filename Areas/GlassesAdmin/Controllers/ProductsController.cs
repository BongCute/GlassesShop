﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace GlassesShop.Areas.GlassesAdmin.Controllers
{
    public class ProductsController : Controller
    {
        private GlassesShopDBContex db = new GlassesShopDBContex();

        // GET: GlassesAdmin/Products
        public ActionResult Index()
        {
            var products = db.Product.Include(p => p.Category).Include(p => p.Promotion);
            return View(products.ToList());
        }

        // GET: GlassesAdmin/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: GlassesAdmin/Products/Create
        public ActionResult Create()
        {
            ViewBag.ID_Category = new SelectList(db.Category, "ID_Category", "Name");
            ViewBag.ID_Promotion = new SelectList(db.Promotion, "ID_Promotion", "Name");
            return View();
        }

        // POST: GlassesAdmin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Product,Name,Description,imageLink,imageList,price,discount,MetaTitle,Hot,CreateProduct,ID_Category,ID_Promotion")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Category = new SelectList(db.Category, "ID_Category", "Name", product.ID_Category);
            ViewBag.ID_Promotion = new SelectList(db.Promotion, "ID_Promotion", "Name", product.ID_Promotion);
            return View(product);
        }

        // GET: GlassesAdmin/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Category = new SelectList(db.Category, "ID_Category", "Name", product.ID_Category);
            ViewBag.ID_Promotion = new SelectList(db.Promotion, "ID_Promotion", "Name", product.ID_Promotion);
            return View(product);
        }

        // POST: GlassesAdmin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Product,Name,Description,imageLink,imageList,price,discount,MetaTitle,Hot,CreateProduct,ID_Category,ID_Promotion")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Category = new SelectList(db.Category, "ID_Category", "Name", product.ID_Category);
            ViewBag.ID_Promotion = new SelectList(db.Promotion, "ID_Promotion", "Name", product.ID_Promotion);
            return View(product);
        }

        // GET: GlassesAdmin/Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: GlassesAdmin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
