using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartegraph.Models
{
   public class IssueTypes
    {
        public int IssueID { get; set; }

        public string IssueType { get; set; }
    }

    public class IssueTypeData
    {
        [JsonProperty("data")]

        public IEnumerable<IssueTypes> data { get; set; }
    }
}
