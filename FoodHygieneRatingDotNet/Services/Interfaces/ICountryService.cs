using FoodHygieneRatingDotNet.Entities;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface ICountryService : IRetrievableCollection<Countries>, IRetrievableBasicCollection<Countries>, IRetrievableIndividual<Country>
    {
    }
}
