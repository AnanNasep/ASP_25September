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
    public class RuangsController : Controller
    {
        private rumahsakit_25092021Entities2 db = new rumahsakit_25092021Entities2();

        // GET: Ruangs
        public ActionResult Index()
        {
            var ruangs = db.Ruangs.Include(r => r.Kela);
            return View(ruangs.ToList());
        }

        // GET: Ruangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruang ruang = db.Ruangs.Find(id);
            if (ruang == null)
            {
                return HttpNotFound();
            }
            return View(ruang);
        }

        // GET: Ruangs/Create
        public ActionResult Create()
        {
            ViewBag.KodeKelas = new SelectList(db.Kelas, "KodeKelas", "NamaKelas");
            return View();
        }

        // POST: Ruangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KodeRuang,NamaRuang,KodeKelas")] Ruang ruang)
        {
            if (ModelState.IsValid)
            {
                db.Ruangs.Add(ruang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KodeKelas = new SelectList(db.Kelas, "KodeKelas", "NamaKelas", ruang.KodeKelas);
            return View(ruang);
        }

        // GET: Ruangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruang ruang = db.Ruangs.Find(id);
            if (ruang == null)
            {
                return HttpNotFound();
            }
            ViewBag.KodeKelas = new SelectList(db.Kelas, "KodeKelas", "NamaKelas", ruang.KodeKelas);
            return View(ruang);
        }

        // POST: Ruangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KodeRuang,NamaRuang,KodeKelas")] Ruang ruang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ruang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KodeKelas = new SelectList(db.Kelas, "KodeKelas", "NamaKelas", ruang.KodeKelas);
            return View(ruang);
        }

        // GET: Ruangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruang ruang = db.Ruangs.Find(id);
            if (ruang == null)
            {
                return HttpNotFound();
            }
            return View(ruang);
        }

        // POST: Ruangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ruang ruang = db.Ruangs.Find(id);
            db.Ruangs.Remove(ruang);
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
