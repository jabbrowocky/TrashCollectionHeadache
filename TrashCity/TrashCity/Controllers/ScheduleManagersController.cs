using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCity.Models;

namespace TrashCity.Controllers
{
    public class ScheduleManagersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScheduleManagers
        public ActionResult Index()
        {
            var scheduleManager = db.ScheduleManager.Include(s => s.customer);
            return View(scheduleManager.ToList());
        }

        // GET: ScheduleManagers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleManager scheduleManager = db.ScheduleManager.Find(id);
            if (scheduleManager == null)
            {
                return HttpNotFound();
            }
            return View(scheduleManager);
        }

        // GET: ScheduleManagers/Create
        public ActionResult Schedule()
        {
            
            return View();
        }

        // POST: ScheduleManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Schedule([Bind(Include = "CustomerId,dateToChange,tempCollectionDay")] ScheduleManager scheduleManager, CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                
                db.ScheduleManager.Add(scheduleManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.CustomerModels, "CustomerId", "CustomerFirstName", scheduleManager.CustomerId);
            return View(scheduleManager);
        }

        // GET: ScheduleManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleManager scheduleManager = db.ScheduleManager.Find(id);
            if (scheduleManager == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.CustomerModels, "CustomerId", "CustomerFirstName", scheduleManager.CustomerId);
            return View(scheduleManager);
        }

        // POST: ScheduleManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,dateToChange,tempCollectionDay")] ScheduleManager scheduleManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.CustomerModels, "CustomerId", "CustomerFirstName", scheduleManager.CustomerId);
            return View(scheduleManager);
        }

        // GET: ScheduleManagers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleManager scheduleManager = db.ScheduleManager.Find(id);
            if (scheduleManager == null)
            {
                return HttpNotFound();
            }
            return View(scheduleManager);
        }

        // POST: ScheduleManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleManager scheduleManager = db.ScheduleManager.Find(id);
            db.ScheduleManager.Remove(scheduleManager);
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
