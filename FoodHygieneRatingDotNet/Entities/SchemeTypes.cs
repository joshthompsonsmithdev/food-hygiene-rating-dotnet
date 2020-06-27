using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    public class SchemeTypes : EntityBase
    {
        [JsonProperty("schemetypes")]
        public List<SchemeType> Data { get; set; }
    }
}
