using System.Collections.Generic;

namespace FoodHygieneRatingDotNet.Entities
{
    public abstract class EntityBase
    {
        public IList<Link> Links { get; set; }
    }
}