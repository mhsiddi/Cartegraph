using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartegraph.Models.Employee
{
    public class EmployeeData
    {
        [JsonProperty("data")]
        public IEnumerable<Employees> data { get; set; }
    }
}
