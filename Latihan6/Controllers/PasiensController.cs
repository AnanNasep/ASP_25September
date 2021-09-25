using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Latihan6.Models;

namespace Latihan6.Controllers
{
    public class PasiensController : Controller
    {
        private rumahsakit_25092021Entities2 db = new rumahsakit_25092021Entities2();

        // GET: Pasiens
        public ActionResult Index()
        {
            return View(db.Pasiens.ToList());
        }

        // GET: Pasiens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return HttpNotFound();
            }
            return View(pasien);
        }

        // GET: Pasiens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pasiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KodePasien,NamaPasien,Foto")] Pasien pasien, HttpPostedFileBase LokasiFoto)
        {

            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(LokasiFoto.FileName);
                string FileExtension = Path.GetFileName(LokasiFoto.FileName);
                fileName = DateTime.Now.ToString("yyyyMMdd") + "-" + fileName.Trim() + FileExtension;
                string _path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                LokasiFoto.SaveAs(_path);
                pasien.Foto = fileName;

                db.Pasiens.Add(pasien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pasien);
        }

        // GET: Pasiens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return HttpNotFound();
            }
            return View(pasien);
        }

        // POST: Pasiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KodePasien,NamaPasien,Foto")] Pasien pasien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pasien);
        }

        // GET: Pasiens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return HttpNotFound();
            }
            return View(pasien);
        }

        // POST: Pasiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pasien pasien = db.Pasiens.Find(id);
            db.Pasiens.Remove(pasien);
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
