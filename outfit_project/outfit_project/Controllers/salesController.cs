using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using outfit_project.Models;

namespace outfit_project.Controllers
{
    public class salesController : Controller
    {
        private outfitEntities1 db = new outfitEntities1();

        // GET: sales
        public ActionResult Index()
        {
            var sale = db.sale.Include(s => s.reservation).Include(s => s.seller);
            return View(sale.ToList());
        }

        // GET: sales/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sale sale = db.sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: sales/Create
        public ActionResult Create()
        {
            ViewBag.id_reservation = new SelectList(db.reservation, "id_reservation", "id_reservation");
            ViewBag.id_seller = new SelectList(db.seller, "id_seller", "names");
            return View();
        }

        // POST: sales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_sale,date,total,id_reservation,id_seller")] sale sale)
        {
            if (ModelState.IsValid)
            {
                db.sale.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_reservation = new SelectList(db.reservation, "id_reservation", "id_reservation", sale.id_reservation);
            ViewBag.id_seller = new SelectList(db.seller, "id_seller", "names", sale.id_seller);
            return View(sale);
        }

        // GET: sales/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sale sale = db.sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_reservation = new SelectList(db.reservation, "id_reservation", "id_reservation", sale.id_reservation);
            ViewBag.id_seller = new SelectList(db.seller, "id_seller", "names", sale.id_seller);
            return View(sale);
        }

        // POST: sales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_sale,date,total,id_reservation,id_seller")] sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_reservation = new SelectList(db.reservation, "id_reservation", "id_reservation", sale.id_reservation);
            ViewBag.id_seller = new SelectList(db.seller, "id_seller", "names", sale.id_seller);
            return View(sale);
        }

        // GET: sales/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sale sale = db.sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            sale sale = db.sale.Find(id);
            db.sale.Remove(sale);
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
