using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TrashCity.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            
            if (User.Identity.IsAuthenticated && User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "CustomerModels");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("Employee"))
            {
                return RedirectToAction("Index", "EmployeeModels");
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}