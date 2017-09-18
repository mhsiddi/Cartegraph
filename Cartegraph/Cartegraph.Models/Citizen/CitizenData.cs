using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cartegraph.Models
{
    public class CitizenData
    {
        [JsonProperty("data")]
        public IEnumerable<Citizens> data { get; set; }
    }
}
