using Cartegraph.Business;
using Cartegraph.Models;
using Cartegraph.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cartegraph.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeService svc;

        public EmployeesController(IEmployeeService _svc)
        {
            svc = _svc;
        }

        public EmployeesController()
        {
            svc = new EmployeeService();
        }
        public ActionResult GetAllEmployees()
        {
            Employees request = new Employees();
            List<Employees> empList = new List<Employees>();

             empList = svc.GetAllEmployees(request).data.Select(e => new Employees()
             {
                 EmployeeID = e.EmployeeID,
                 FullNameandID = e.FirstName + " " + e.LastName + " (" + e.EmployeeID + ")"

             }).ToList();

            return Json(empList, JsonRequestBehavior.AllowGet);
        }
    }
}