using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    public class RatingOperators : EntityBase
    {
        [JsonProperty("ratingOperator")]
        public List<RatingOperator> Data { get; set; }
    }
}
