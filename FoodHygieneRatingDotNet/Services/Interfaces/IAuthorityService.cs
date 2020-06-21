using FoodHygieneRatingDotNet.Entities;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface IAuthorityService : IRetrievableCollection<Authorities>, IRetrievableBasicCollection<Authorities>, IRetrievableIndividual<Authority>
    {
    }
}
