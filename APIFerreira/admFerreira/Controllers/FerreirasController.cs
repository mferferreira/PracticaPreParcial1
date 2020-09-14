using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admFerreira.Models;

namespace admFerreira.Controllers
{
    public class FerreirasController : Controller
    {
        private DataContext db = new DataContext();


        // GET: Ferreiras
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Ferreiras.ToList());
        }


        // GET: Ferreiras/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ferreira ferreira = db.Ferreiras.Find(id);
            if (ferreira == null)
            {
                return HttpNotFound();
            }
            return View(ferreira);
        }


        // GET: Ferreiras/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ferreiras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FerreiraID,FriendofFerreira,place,Email,Birthdate")] Ferreira ferreira)
        {
            if (ModelState.IsValid)
            {
                db.Ferreiras.Add(ferreira);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ferreira);
        }



        // GET: Ferreiras/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ferreira ferreira = db.Ferreiras.Find(id);
            if (ferreira == null)
            {
                return HttpNotFound();
            }
            return View(ferreira);
        }
        
        
        // POST: Ferreiras/Edit/5
          [Authorize]
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FerreiraID,FriendofFerreira,place,Email,Birthdate")] Ferreira ferreira)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ferreira).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ferreira);
        }



        // GET: Ferreiras/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ferreira ferreira = db.Ferreiras.Find(id);
            if (ferreira == null)
            {
                return HttpNotFound();
            }
            return View(ferreira);
        }

        // POST: Ferreiras/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ferreira ferreira = db.Ferreiras.Find(id);
            db.Ferreiras.Remove(ferreira);
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
