using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    public class SortOptions : EntityBase
    {
        [JsonProperty("sortoptions")]
        public List<SortOption> Data { get; set; }
    }
}
