using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentNasa.Models
{
    public class Photo
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "sol")]
        public int Sol { get; set; }

        [JsonProperty(PropertyName = "camera")]
        public Camera Camera { get; set; }

        [JsonProperty(PropertyName = "img_src")]
        public string ImgSrc { get; set; }

        [JsonProperty(PropertyName = "earth_date")]
        public DateTime EarthDate { get; set; }

        [JsonProperty(PropertyName = "rover")]
        public Rover Rover { get; set; }

    }
}
