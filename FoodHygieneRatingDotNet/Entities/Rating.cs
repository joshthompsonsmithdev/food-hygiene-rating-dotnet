namespace FoodHygieneRatingDotNet.Entities
{
    public class Rating : EntityBase
    {
        public int RatingId { get; set; }

        public string RatingName { get; set; }

        public string RatingKey { get; set; }

        public string RatingKeyName { get; set; }

        public int SchemeTypeId { get; set; }
    }
}
