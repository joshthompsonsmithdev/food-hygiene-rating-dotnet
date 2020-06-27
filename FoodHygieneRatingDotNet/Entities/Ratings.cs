using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    public class Ratings : EntityBase
    {
        [JsonProperty("ratings")]
        public List<Rating> Data { get; set; }
    }
}
