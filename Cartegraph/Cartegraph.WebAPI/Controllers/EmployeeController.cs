using Cartegraph.Business;
using Cartegraph.Models;
using Cartegraph.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartegraph.WebAPI.Controllers
{
    
    public class EmployeeController
    {
        private IEmployeeService svc;

        public EmployeeController(IEmployeeService _svc)
        {
            svc = _svc;
        }

        public EmployeeController()
        {
            svc = new EmployeeService();
        }

        //[Route]
        public async Task<EmployeeData> GetAllEmployees([FromBody]Employees request)
        {
            return await svc.GetAllEmployees(request);
        }

    }
}
