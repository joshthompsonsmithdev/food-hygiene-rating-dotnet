using System;

namespace FoodHygieneRatingDotNet.Entities
{
    /// <summary>
    /// The local authority for a given FHRS rating that is shared between detailed and basic requests.
    /// Additional information can be found here: https://api.ratings.food.gov.uk/Help.
    /// </summary>
    public class Authority : EntityBase
    {
        public int LocalAuthorityId { get; set; }

        public string LocalAuthorityIdCode { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public string Url { get; set; }

        public string SchemeUrl { get; set; }

        public string Email { get; set; }

        public string RegionName { get; set; }

        public string FileName { get; set; }

        public string FileNameWelsh { get; set; }

        public int EstablishmentCount { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastPublishDate { get; set; }

        public int SchemeType { get; set; }
    }
}