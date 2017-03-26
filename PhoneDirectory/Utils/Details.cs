using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using PhoneDirectory.Models;
using System.Data.Entity;

namespace PhoneDirectory.Utils
{
    public class Details
    {
       protected static PhoneDirectoryEntities db = new PhoneDirectoryEntities();

        public static int getSeniority( Employee emp)
        {
            int Seniority = 2; //  2 :Employee - 1 : Manager - 0 :Gneral Manager 
            var empList = db.Employee.ToList();
            var result = empList.Where(e => e.managerID == emp.ID).FirstOrDefault();

            if (result != null) {
                if (haveManager(emp))
                {
                    Seniority = 1;
                }
                else
                {
                    Seniority = 0;
                }

            }

            return Seniority;
        }

        public static HtmlString getAdmin(int id)
        {
            
            Employee emp = (Employee)db.Employee.Find(id);
            string name ="Admin : "+ emp.name.ToString() +" "+ emp.surname.ToString();

            var admin = new HtmlString(name);

            return admin;
        }

        public static bool haveManager(Employee emp) // Yöneticisi olup olmadığını bildirir.
        {
            bool haveManager = true;

            if (emp.managerID.ToString() == string.Empty) { haveManager = false; }

            return haveManager;
        }
    }
}