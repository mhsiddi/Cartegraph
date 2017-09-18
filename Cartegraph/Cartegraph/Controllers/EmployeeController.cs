using Cartegraph.Business;
using Cartegraph.Models;
using Cartegraph.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Cartegraph.Controllers
{
   
    public class EmployeeController : Controller
    {
        IEmployeeService svc;

        public EmployeeController(IEmployeeService _svc)
        {
            svc = _svc;
        }

        public EmployeeController()
        {
            svc = new EmployeeService();
        }
        public ActionResult GetAllEmployees()
        {
            Employees employees = new Employees();
            EmployeeData results = new EmployeeData();
            try
            {
                results = svc.GetAllEmployees(employees);
            }
            catch(Exception ex)
            {

            }
            return Json(results);
        }
    }
}