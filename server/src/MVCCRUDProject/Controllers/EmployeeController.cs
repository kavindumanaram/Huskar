using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUDProject.Models;

namespace MVCCRUDProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            var empList = new List<Employee>();
            using (DBModels db = new DBModels())
            {
                empList = db.Employees.ToList();
            }
            return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                using (DBModels db = new DBModels())
                {
                    return View(db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault());
                }
                }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {

                using (DBModels db = new DBModels())
                {
                if (emp.EmployeeId == 0)
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Succesfully" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Update Succesfully" }, JsonRequestBehavior.AllowGet);
                }

            }

            }

        }
    }
