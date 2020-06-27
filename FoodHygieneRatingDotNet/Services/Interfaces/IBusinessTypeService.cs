using FoodHygieneRatingDotNet.Entities;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface IBusinessTypeService : IRetrievableCollection<BusinessTypes>, IRetrievableBasicCollection<BusinessTypes>, IRetrievableIndividual<BusinessType>
    {
    }
}
