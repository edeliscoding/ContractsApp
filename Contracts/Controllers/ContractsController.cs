﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contracts.Models;

namespace Contracts.Controllers
{
    public class ContractsController : Controller
    {
        private ContractsDb db = new ContractsDb();

        // GET: Contracts
        public ActionResult Index()
        {
            var initial = from t in db.Contracts
                          where t.Status == null
                          select t;
            return View(initial.ToList());
        }

        // GET: Contracts/Pending/id
        public ActionResult Pending()
        {
            var contract = from t in db.Contracts
                           where t.Status == "Pending"
                           select t;
            return View(contract.ToList());
        }

        public ActionResult ReadyToSign()
        {
            var contract = from t in db.Contracts
                           where t.Status == "Ready"
                           select t;
            return View(contract.ToList());
        }
        public ActionResult ProviderSigned()
        {
            var contract = from t in db.Contracts
                           where t.Status == "ProviderSigned"
                           select t;
            return View(contract.ToList());
        }

        public ActionResult Final()
        {
            var contract = from t in db.Contracts
                           where t.Status == "Final"
                           select t;
            return View(contract.ToList());
        }


        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contract);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
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
