using System;
using Newtonsoft.Json;

namespace AppPontChaban.Models
{
    public class FormatApi
    {
        [JsonProperty("boat_name")]
        public string BoatName { get; set; }

        [JsonProperty("closing_type")]
        public string ClosingType { get; set; }

        [JsonProperty("closing_date")]
        public DateTime ClosingDate { get; set; }

        [JsonProperty("reopening_date")]
        public DateTime ReopeningDate { get; set; }

        [JsonProperty("Risquedebouchons")]
        public string Risquedebouchons { get; set; }
    }
}
