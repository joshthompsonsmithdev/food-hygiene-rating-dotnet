using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    public class Regions : EntityBase
    {
        [JsonProperty("regions")]
        public List<Region> Data { get; set; }
    }
}
