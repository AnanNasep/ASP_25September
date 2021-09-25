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
    public class KelasController : Controller
    {
        private rumahsakit_25092021Entities2 db = new rumahsakit_25092021Entities2();

        // GET: Kelas
        public ActionResult Index()
        {
            return View(db.Kelas.ToList());
        }

        // GET: Kelas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kela kela = db.Kelas.Find(id);
            if (kela == null)
            {
                return HttpNotFound();
            }
            return View(kela);
        }

        // GET: Kelas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kelas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KodeKelas,NamaKelas,Harga")] Kela kela)
        {
            if (ModelState.IsValid)
            {
                db.Kelas.Add(kela);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kela);
        }

        // GET: Kelas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kela kela = db.Kelas.Find(id);
            if (kela == null)
            {
                return HttpNotFound();
            }
            return View(kela);
        }

        // POST: Kelas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KodeKelas,NamaKelas,Harga")] Kela kela)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kela).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kela);
        }

        // GET: Kelas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kela kela = db.Kelas.Find(id);
            if (kela == null)
            {
                return HttpNotFound();
            }
            return View(kela);
        }

        // POST: Kelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Kela kela = db.Kelas.Find(id);
            db.Kelas.Remove(kela);
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
