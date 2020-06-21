using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    public class BusinessTypes : EntityBase
    {
        [JsonProperty("businesstypes")]
        public List<BusinessType> Data { get; set; }
    }
}
