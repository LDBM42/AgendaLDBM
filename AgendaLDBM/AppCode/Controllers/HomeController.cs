using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgendaLDBM.Services;

namespace AgendaLDBM.AppCode.Controllers
{
    public class HomeController : Controller
    {
        private GlobalDBContext db = new GlobalDBContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.AgendaEntidads.ToList());
        }

        // GET: Home/Notes/5
        public ActionResult Notes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendaEntidad agendaEntidad = db.AgendaEntidads.Find(id);
            if (agendaEntidad == null)
            {
                return HttpNotFound();
            }
            return View(agendaEntidad);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Télefono,Notas")] AgendaEntidad agendaEntidad)
        {
            if (ModelState.IsValid)
            {
                db.AgendaEntidads.Add(agendaEntidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agendaEntidad);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendaEntidad agendaEntidad = db.AgendaEntidads.Find(id);
            if (agendaEntidad == null)
            {
                return HttpNotFound();
            }
            return View(agendaEntidad);
        }

        // POST: Home/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Télefono,Notas")] AgendaEntidad agendaEntidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendaEntidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agendaEntidad);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendaEntidad agendaEntidad = db.AgendaEntidads.Find(id);
            if (agendaEntidad == null)
            {
                return HttpNotFound();
            }
            return View(agendaEntidad);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgendaEntidad agendaEntidad = db.AgendaEntidads.Find(id);
            db.AgendaEntidads.Remove(agendaEntidad);
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
