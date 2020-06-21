namespace FoodHygieneRatingDotNet.Entities
{
    public class Country : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameKey { get; set; }

        public string Code { get; set; }
    }
}