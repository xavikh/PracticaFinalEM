﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PracticaEM.Models;

namespace PracticaEM.Controllers
{
    public class AsignacionDocentesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsignacionDocentes
        public ActionResult Index()
        {
            return View(db.AsignacionDocentes.ToList());
        }

        // GET: AsignacionDocentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocente asignacionDocente = db.AsignacionDocentes.Find(id);
            if (asignacionDocente == null)
            {
                return HttpNotFound();
            }
            return View(asignacionDocente);
        }

        // GET: AsignacionDocentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsignacionDocentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsigDocente,Mail,Ano,Nombre")] AsignacionDocente asignacionDocente)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionDocentes.Add(asignacionDocente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asignacionDocente);
        }

        // GET: AsignacionDocentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocente asignacionDocente = db.AsignacionDocentes.Find(id);
            if (asignacionDocente == null)
            {
                return HttpNotFound();
            }
            return View(asignacionDocente);
        }

        // POST: AsignacionDocentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsigDocente,Mail,Ano,Nombre")] AsignacionDocente asignacionDocente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionDocente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignacionDocente);
        }

        // GET: AsignacionDocentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocente asignacionDocente = db.AsignacionDocentes.Find(id);
            if (asignacionDocente == null)
            {
                return HttpNotFound();
            }
            return View(asignacionDocente);
        }

        // POST: AsignacionDocentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionDocente asignacionDocente = db.AsignacionDocentes.Find(id);
            db.AsignacionDocentes.Remove(asignacionDocente);
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