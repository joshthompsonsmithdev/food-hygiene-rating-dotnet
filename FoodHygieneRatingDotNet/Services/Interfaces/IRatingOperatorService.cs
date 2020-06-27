using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface IRatingOperatorService
    {
        /// <summary>
        /// Retrieves details of all RatingOperators.
        /// </summary>
        /// <returns>Returns details of all RatingOperators.</returns>
        Task<FhrResponse<RatingOperators>> GetAsync();
    }
}
