using System;
using System.Collections.Generic;
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
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Saved Succesfully" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}