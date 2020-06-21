using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    public class Establishments : EntityBase
    {
        [JsonProperty("establishments")]
        public List<Establishment> Data { get; set; }
    }
}
