using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneDirectory.Models;
using System.Data.Entity;

namespace PhoneDirectory.Controllers
{
    public class HomeController : Controller
    {
        private PhoneDirectoryEntities db = new PhoneDirectoryEntities();
        // GET: Home
    

        public ActionResult Rehber()
        {
            ViewData["isAtRehber"] = true;

            return View(db.Employee.ToList().OrderBy(e => e.departmentID));
        }
        public ActionResult LogIn()
        {
            if (Session["admin"] != null && Session["admin"].ToString() == "1")
            {
                return Redirect("~/Admin/Index");
            }
            ViewData["isAtRehber"] = false;
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewData["isAtRehber"] = false;
            Employee emp = db.Employee.Find(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult logIn(FormCollection frm)
        {
           

            string username = frm["username"].ToString().Trim();
            string pass = frm["password"].ToString().Trim();

            var query = db.Admins.ToList();
            var result = query.Where(e => e.username == username && e.password == pass).SingleOrDefault();
            Admins admin = (Admins)result;

            if (result != null && admin != null)
            {
                Session["admin"] = 1;
                Session["adminID"] = admin.ID;
                Session["adminEmpID"] = admin.employeeID;
                return Redirect("~/calisan-listesi");
            }

            return RedirectToAction("Rehber");


        }

    }
}