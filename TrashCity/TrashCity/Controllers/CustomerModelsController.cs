using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCity.Models;
using Microsoft.AspNet.Identity;

namespace TrashCity.Controllers
{
    public class CustomerModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerModels
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            
            CustomerModel customerModel = new CustomerModel();
            foreach (CustomerModel customer in db.CustomerModels)
            {
                if (customer.UserId == id)
                {

                    customerModel = customer;
                    return View(customerModel);
                }

            }            
            
            return RedirectToAction("Index","Home");
            
        }

        public ActionResult SetCollectionDay()
        {

            var id = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = new CustomerModel();
            foreach (CustomerModel customer in db.CustomerModels)
            {
                if (customer.UserId == id)
                {
                    customerModel = customer;
                }
               
            }
                        
            return View(customerModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetCollectionDay([Bind(Include = "CustomerId,CustomerFirstName,CustomerLastName,CustomerAddress,AmountOwed,CustomerZip,CollectionDay,UserId")]CustomerModel customerModel)
        //public ActionResult SetCollectionDay(int id)
        {

            if (ModelState.IsValid)
            {
                
                db.Entry(customerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Schedule()
        {
            var id = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = new CustomerModel();
            foreach (CustomerModel customer in db.CustomerModels)
            {
                if (customer.UserId == id)
                {
                    customerModel = customer;
                }

            }
            ScheduleManager schedule = new ScheduleManager();
            schedule.CustomerId = customerModel.CustomerId;
            ViewBag.reschedulerDate = schedule.dateToChange;
            return View(schedule);
            
        }

        // POST: ScheduleManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Schedule([Bind(Include = "CustomerId,dateToChange,tempCollectionDay")] ScheduleManager scheduleManager)
        {
            if (ModelState.IsValid)
            {
                scheduleManager.temporaryCollectionDay = scheduleManager.dateToChange.Value.DayOfWeek;
                db.ScheduleManagers.Add(scheduleManager);
                foreach(ScheduleManager schedule in db.ScheduleManagers)
                {
                    if (scheduleManager.CustomerId == schedule.CustomerId && scheduleManager.changeId != schedule.changeId)
                    {
                        db.ScheduleManagers.Remove(schedule);
                    }
                }
                db.SaveChanges(); 
                
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.CustomerModels, "CustomerId", "CustomerFirstName", scheduleManager.CustomerId);
            ViewBag.rescheduleDate = scheduleManager.dateToChange;
            return View(scheduleManager);
        }
        // GET: CustomerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = db.CustomerModels.Find(id);
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        // GET: CustomerModels/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: CustomerModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CustomerFirstName,CustomerLastName,CustomerAddress,CustomerZip")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                
                customerModel.UserId = User.Identity.GetUserId();
                db.CustomerModels.Add(customerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerModel);
        }

        // GET: CustomerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = db.CustomerModels.Find(id);
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }
       
        // POST: CustomerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerFirstName,CustomerLastName,CustomerAddress,CustomerZip")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerModel);
        }

        // GET: CustomerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = db.CustomerModels.Find(id);
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        // POST: CustomerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerModel customerModel = db.CustomerModels.Find(id);
            db.CustomerModels.Remove(customerModel);
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
