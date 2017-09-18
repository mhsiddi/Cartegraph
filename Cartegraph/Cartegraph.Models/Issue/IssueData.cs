using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartegraph.Models.Issue
{
    public class IssueData
    {
        [JsonProperty("data")]
        public IEnumerable<Issues> data { get; set; }
    }

    public class IssueInsertResponse
    {
        [JsonProperty("data")]
        public int data { get; set; }
    }
}
