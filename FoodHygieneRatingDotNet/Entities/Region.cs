using Newtonsoft.Json;

namespace FoodHygieneRatingDotNet.Entities
{
    public class Region : EntityBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameKey")]
        public string NameKey { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
