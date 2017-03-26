using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneDirectory.Models;
using System.Text;
using System.Data.Entity;
using PhoneDirectory.Utils;

namespace PhoneDirectory.Controllers
{
    public class AdminController : BaseControllers
    {
        // GET: Admin
        private PhoneDirectoryEntities db = new PhoneDirectoryEntities();

        #region çalışan

        public ActionResult Index()
        {

            return View(db.Employee.ToList().OrderBy(e => e.departmentID));

        }
        //Çalışan ekleme işlemleri
        public ActionResult addEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addEmployee(Employee emp)
        {
            if (emp.departmentID != null)
            {
                emp.Department = db.Department.Find(emp.departmentID);
                if (emp.managerID != null) { emp.Employee2 = db.Employee.Find(emp.managerID); }

            }
           
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Added;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        
        // çalışan düzenleme
        public ActionResult editEmployee(int id)
        {
            Employee emp = db.Employee.Find(id);
            return View(emp);

        }
        [HttpPost]
        public ActionResult editEmployee(Employee emp)
        {
            if(emp.departmentID != null)
            {
                emp.Department = db.Department.Find(emp.departmentID);
                if(emp.managerID != null) { emp.Employee2 = db.Employee.Find(emp.managerID); }

            }
            
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // çalışan Silme işlemleri
        public ActionResult deleteEmployee(int id)
        {
            Employee employee;
            try
            {
                employee = (Employee)db.Employee.First(c => c.ID == id);
            }
            catch
            {
                TempData["error"] = "Silmeye Çalıştığınız Kişiye Ulaşamadık"; return RedirectToAction("error");
            }
            
            try
            {
                db.Employee.Attach(employee);
                db.Employee.Remove(employee);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                if (ex.ToString().IndexOf("FK_Employee_Employee") != -1 || ex.ToString().IndexOf("FK_Admins_Employee") != -1) { TempData["error"] = "Silmeye Çalıştığınız :"+ employee.name+" "+employee.surname  + " Adlı Çalışan Yönetici Statüsündedir";}
                else { TempData["error"] = "Tanımlanamayan Bir Hata Oluştu"; }

                return RedirectToAction("error");
            }
            
            return RedirectToAction("Index");

        }

        #endregion

        #region departman 

        public ActionResult Departments()
        {

            return View(db.Department.ToList());

        }
        // departman ekleme işlemleri

        public ActionResult addDepartments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addDepartments(Department dep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dep).State = EntityState.Added;
                db.SaveChanges();
            }
            return RedirectToAction("Departments");
        }
        // departman düzenleme işlemleri

        public ActionResult editDepartment(int id)
        {
            Department dep = db.Department.Find(id);
            return View(dep);
        }
        [HttpPost]
        public ActionResult editDepartment(Department dep)
        {

            if (ModelState.IsValid)
            {
                db.Entry(dep).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Departments");
        }
        // departman silme işlemleri
        public ActionResult deleteDepartment(int id)
        {
            Department department;
            try
            {
                department = (Department)db.Department.First(c => c.ID == id);
            }
            catch
            {
                TempData["error"] = "Silmeye Çalıştığınız Departmanna Ulaşamadık"; return RedirectToAction("error");
            }

            try
            {
                db.Department.Attach(department);
                db.Department.Remove(department);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("FK_Employee_Department") != -1) { TempData["error"] = "Silmeye Çalıştığınız " + department.name + "'nına Kayıtlı Çalışan Bulunmaktadır"; }
                else { TempData["error"] = "Tanımlanamayan Bir Hata Oluştu"; }

                return RedirectToAction("error");
            }

            return RedirectToAction("Departments");

        }

        #endregion

        #region admin güncelle
        public ActionResult changePass(int id)
        {
            Admins adm = db.Admins.Find(id);
            return View(adm);
        }
        [HttpPost]
        public ActionResult changePass(Admins adm)
        {
            if(adm.employeeID != null)
            {
                adm.Employee = db.Employee.Find(adm.employeeID);
            }
            if (Session["adminID"] != null)
            {
                adm.ID = Convert.ToInt32(Session["adminID"]);

                    db.Entry(adm).State = EntityState.Modified;
                    db.SaveChanges();
                    Session.Clear();
                    return RedirectToAction("Index");
              
                
            }
            return View("changePass");


        }

        #endregion

        public ActionResult error()
        {
            TempData["error"] = TempData["error"];
            return View();

        }
        // oturum kapatma
        public ActionResult Exit()
        {
            if(Session["admin"]!=null && Session["adminEmpID"] != null)
            {
                Session.Clear();
                return Redirect("~/rehber");

            }
            return View();

        }

        



    }
}