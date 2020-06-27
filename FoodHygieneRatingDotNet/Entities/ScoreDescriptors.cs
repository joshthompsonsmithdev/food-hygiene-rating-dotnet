using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    public class ScoreDescriptors : EntityBase
    {
        [JsonProperty("scoreDescriptors")]
        public List<ScoreDescriptor> Data { get; set; }
    }
}
