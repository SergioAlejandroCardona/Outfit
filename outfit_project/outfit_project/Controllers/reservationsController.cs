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
    public class reservationsController : Controller
    {
        private outfitEntities1 db = new outfitEntities1();

        // GET: reservations
        public ActionResult Index()
        {
            var reservation = db.reservation.Include(r => r.customer).Include(r => r.product);
            return View(reservation.ToList());
        }

        // GET: reservations/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: reservations/Create
        public ActionResult Create()
        {
            ViewBag.id_customer = new SelectList(db.customer, "id_customer", "document_type");
            ViewBag.id_product = new SelectList(db.product, "id_product", "name");
            return View();
        }

        // POST: reservations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reservation,id_customer,id_product")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.reservation.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_customer = new SelectList(db.customer, "id_customer", "document_type", reservation.id_customer);
            ViewBag.id_product = new SelectList(db.product, "id_product", "name", reservation.id_product);
            return View(reservation);
        }

        // GET: reservations/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_customer = new SelectList(db.customer, "id_customer", "document_type", reservation.id_customer);
            ViewBag.id_product = new SelectList(db.product, "id_product", "name", reservation.id_product);
            return View(reservation);
        }

        // POST: reservations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reservation,id_customer,id_product")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_customer = new SelectList(db.customer, "id_customer", "document_type", reservation.id_customer);
            ViewBag.id_product = new SelectList(db.product, "id_product", "name", reservation.id_product);
            return View(reservation);
        }

        // GET: reservations/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            reservation reservation = db.reservation.Find(id);
            db.reservation.Remove(reservation);
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
