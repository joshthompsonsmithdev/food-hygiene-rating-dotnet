using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface IRatingService
    {
        /// <summary>
        /// Retrieves details of all Ratings.
        /// </summary>
        /// <returns>Returns details of all Ratings.</returns>
        Task<FhrResponse<Ratings>> GetAsync();
    }
}
