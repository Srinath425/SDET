using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCapitalByState
{
    public class StateModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("abbr")]
        public string Abbr { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("largest_city")]
        public string LargestCity { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

        public string ErrorMessage { get; set; }
    }
}
