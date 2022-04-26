using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FetchRustAPI.Models
{
    class datasModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("device")]
        public string Device { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
