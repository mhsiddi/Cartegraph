
using Cartegraph.Data.Repository;
using Cartegraph.Models;
using Cartegraph.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartegraph.Business
{
    public interface IEmployeeService
    {
        EmployeeData GetAllEmployees(Employees request); 
    }
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepo;

        public EmployeeService()
        {
            employeeRepo = new EmployeeRepository();
        }

        public EmployeeService(IEmployeeRepository _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }

        public EmployeeData GetAllEmployees(Employees request)
        {
            EmployeeData response = new EmployeeData();
            try
            {
                response.data = employeeRepo.GetAllEmployees(request);
            }
            catch (Exception ex)
            {
                // do something w/ the error
            }
            return response;
        }
    }
}
