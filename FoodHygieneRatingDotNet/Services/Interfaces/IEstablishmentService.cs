using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface IEstablishmentService : IRetrievableBasicCollection<Establishments>, IRetrievableIndividual<Establishment>
    {
        /// <summary>
        /// Retrieves a collection of establishment details, based on provided search parameters. 
        /// All search parameters are optional.
        /// </summary>
        /// <param name="criteria">The optional parameter criteria.</param>
        /// <returns>
        /// Returns a collection of establishment details, based on provided search parameters. 
        /// All search parameters are optional.
        /// </returns>
        Task<FhrResponse<Establishments>> GetBasicAsync(EstablishmentSearchCriteria criteria);
    }
}
