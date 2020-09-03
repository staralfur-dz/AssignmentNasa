using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentNasa.Models
{
    public class Camera
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "rover_id")]
        public int RoverId { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }
    }
}
