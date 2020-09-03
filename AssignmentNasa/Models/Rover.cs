using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentNasa.Models
{
    public class Rover
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "landing_date")]
        public DateTime LandingDate { get; set; }

        [JsonProperty(PropertyName = "launch_date")]
        public DateTime LaunchDate { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
