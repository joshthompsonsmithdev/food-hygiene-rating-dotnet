using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    public class Countries : EntityBase
    {
        [JsonProperty("countries")]
        public List<Country> Data { get; set; }
    }
}
