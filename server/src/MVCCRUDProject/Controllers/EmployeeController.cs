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
    }
}