using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Latihan6.Models;

namespace Latihan6.Controllers
{
    public class DoktersController : Controller
    {
        private rumahsakit_25092021Entities2 db = new rumahsakit_25092021Entities2();

        // GET: Dokters
        public ActionResult Index()
        {
            return View(db.Dokters.ToList());
        }

        // GET: Dokters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokter dokter = db.Dokters.Find(id);
            if (dokter == null)
            {
                return HttpNotFound();
            }
            return View(dokter);
        }

        // GET: Dokters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dokters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KodeDokter,NamaDokter,JKelamin")] Dokter dokter)
        {
            if (ModelState.IsValid)
            {
                db.Dokters.Add(dokter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dokter);
        }

        // GET: Dokters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokter dokter = db.Dokters.Find(id);
            if (dokter == null)
            {
                return HttpNotFound();
            }
            return View(dokter);
        }

        // POST: Dokters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KodeDokter,NamaDokter,JKelamin")] Dokter dokter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dokter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dokter);
        }

        // GET: Dokters/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokter dokter = db.Dokters.Find(id);
            if (dokter == null)
            {
                return HttpNotFound();
            }
            return View(dokter);
        }

        // POST: Dokters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dokter dokter = db.Dokters.Find(id);
            db.Dokters.Remove(dokter);
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
