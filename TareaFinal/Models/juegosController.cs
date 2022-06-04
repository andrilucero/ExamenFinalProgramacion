using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TareaFinal.Models
{
    public class juegosController : Controller
    {
        private PrograEntitiesAndri db = new PrograEntitiesAndri();

        // GET: juegos
        public ActionResult Index()
        {
            return View(db.tb_GameStop.ToList());
        }

        // GET: juegos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_GameStop tb_GameStop = db.tb_GameStop.Find(id);
            if (tb_GameStop == null)
            {
                return HttpNotFound();
            }
            return View(tb_GameStop);
        }

        // GET: juegos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: juegos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Juego,Nombre,Categoria,Precio,Fecha,Plataforma,Stock")] tb_GameStop tb_GameStop)
        {
            if (ModelState.IsValid)
            {
                db.tb_GameStop.Add(tb_GameStop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_GameStop);
        }

        // GET: juegos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_GameStop tb_GameStop = db.tb_GameStop.Find(id);
            if (tb_GameStop == null)
            {
                return HttpNotFound();
            }
            return View(tb_GameStop);
        }

        // POST: juegos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Juego,Nombre,Categoria,Precio,Fecha,Plataforma,Stock")] tb_GameStop tb_GameStop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_GameStop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_GameStop);
        }

        // GET: juegos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_GameStop tb_GameStop = db.tb_GameStop.Find(id);
            if (tb_GameStop == null)
            {
                return HttpNotFound();
            }
            return View(tb_GameStop);
        }

        // POST: juegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_GameStop tb_GameStop = db.tb_GameStop.Find(id);
            db.tb_GameStop.Remove(tb_GameStop);
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
