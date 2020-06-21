namespace FoodHygieneRatingDotNet.Entities
{
    public class ScoreDescriptor : EntityBase
    {
        public int Id { get; set; }

        public string ScoreCategory { get; set; }

        public int Score { get; set; }

        public string Description { get; set; }
    }
}
