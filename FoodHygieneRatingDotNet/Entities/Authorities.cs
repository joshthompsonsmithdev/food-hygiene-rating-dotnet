using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    /// <summary>
    /// The local authorities for a given FHRS rating that is shared between detailed and basic requests.
    /// Additional information can be found here: https://api.ratings.food.gov.uk/Help.
    /// </summary>
    public class Authorities : EntityBase
    {
        [JsonProperty("authorities")]
        public List<Authority> Data { get; set; }
    }
}
