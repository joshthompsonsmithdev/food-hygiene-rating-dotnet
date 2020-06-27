using Newtonsoft.Json;
using System;

namespace FoodHygieneRatingDotNet.Entities
{
    public class MetaData
    {
        [JsonProperty("dataSource")]
        public string DataSource { get; set; }

        [JsonProperty("extractDate")]
        public DateTime ExtractDate { get; set; }

        [JsonProperty("itemCount")]
        public int ItemCount { get; set; }

        [JsonProperty("returncode")]
        public string ReturnCode { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }
    }
}
