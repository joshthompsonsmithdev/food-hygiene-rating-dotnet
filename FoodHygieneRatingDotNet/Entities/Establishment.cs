using System;

namespace FoodHygieneRatingDotNet.Entities
{
    public class Establishment : EntityBase
    {
        public int FhrsId { get; set; }

        public string LocalAuthorityBusinessId { get; set; }

        public string BusinessName { get; set; }

        public string BusinessType { get; set; }

        public string BusinessTypeId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }

        public string PostCode { get; set; }

        public string Phone { get; set; }

        public string RatingValue { get; set; }

        public string RatingKey { get; set; }

        public DateTime RatingDate { get; set; }

        public string LocalAuthorityCode { get; set; }

        public string LocalAuthorityName { get; set; }

        public string LocalAuthorityWebSite { get; set; }

        public string LocalAuthorityEmailAddress { get; set; }

        public Score Score { get; set; }

        public string SchemeType { get; set; }

        public GeoCode GeoCode { get; set; }

        public string RightToReply { get; set; }

        public float Distance { get; set; }

        public bool NewRatingPending { get; set; }
    }
}