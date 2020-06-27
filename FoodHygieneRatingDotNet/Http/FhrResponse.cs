using FoodHygieneRatingDotNet.Entities;

namespace FoodHygieneRatingDotNet.Http
{
    public class FhrResponse<T> where T : EntityBase
    {
        public T Response { get; set; }

        public string Message { get; set; }
    }
}
