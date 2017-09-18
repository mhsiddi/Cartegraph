using Cartegraph.Core;
using Cartegraph.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartegraph.Data.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employees> GetAllEmployees(Employees request);
        
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employees> GetAllEmployees(Employees request)
        {
            List<Employees> employeeList = new List<Employees>();
            List<Tuple<string, object>> parameters = new List<Tuple<string, object>>();

            DataTable result = SQLUtil.ExecuteStoredProcedure("GetAllEmployees", parameters);

            employeeList = (from c in result.AsEnumerable()
                            select new Employees()
                            {
                                EmployeeID = c.Field<int>("EmployeeID"),
                                FirstName = c.Field<string>("FirstName"),
                                LastName = c.Field<string>("LastName"),
                                JobTitle = c.Field<string>("JobTitle")

                            }).ToList();

            return employeeList;
                            
            
        }
    }
}
