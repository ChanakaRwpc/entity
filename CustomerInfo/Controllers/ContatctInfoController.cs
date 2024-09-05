using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerInfo.Context;
using CustomerInfo.Models;

namespace CustomerInfo.Controllers
{
    public class ContatctInfoController : Controller
    {
        private CustomerInforContext db = new CustomerInforContext();

        // GET: ContatctInfo
        public ActionResult Index()
        {
            var contatctInfoModels = db.contatctInfoModels.Include(c => c.CustomerModel);
            return View(contatctInfoModels.ToList());
        }

        // GET: ContatctInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatctInfoModel contatctInfoModel = db.contatctInfoModels.Find(id);
            if (contatctInfoModel == null)
            {
                return HttpNotFound();
            }
            return View(contatctInfoModel);
        }

        // GET: ContatctInfo/Create
        public ActionResult Create()
        {
            ViewBag.Cus_Id = new SelectList(db.customerModels, "Cus_Id", "Cus_FirstName");
            return View();
        }

        // POST: ContatctInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Cus_Id")] ContatctInfoModel contatctInfoModel)
        {
            if (ModelState.IsValid)
            {
                db.contatctInfoModels.Add(contatctInfoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cus_Id = new SelectList(db.customerModels, "Cus_Id", "Cus_FirstName", contatctInfoModel.CustomerModel.Cus_Id);
            return View(contatctInfoModel);
        }

        // GET: ContatctInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatctInfoModel contatctInfoModel = db.contatctInfoModels.Find(id);
            if (contatctInfoModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cus_Id = new SelectList(db.customerModels, "Cus_Id", "Cus_FirstName", contatctInfoModel.CustomerModel.Cus_Id);
            return View(contatctInfoModel);
        }

        // POST: ContatctInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Cus_Id")] ContatctInfoModel contatctInfoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contatctInfoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cus_Id = new SelectList(db.customerModels, "Cus_Id", "Cus_FirstName", contatctInfoModel.CustomerModel.Cus_Id);
            return View(contatctInfoModel);
        }

        // GET: ContatctInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatctInfoModel contatctInfoModel = db.contatctInfoModels.Find(id);
            if (contatctInfoModel == null)
            {
                return HttpNotFound();
            }
            return View(contatctInfoModel);
        }

        // POST: ContatctInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContatctInfoModel contatctInfoModel = db.contatctInfoModels.Find(id);
            db.contatctInfoModels.Remove(contatctInfoModel);
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
