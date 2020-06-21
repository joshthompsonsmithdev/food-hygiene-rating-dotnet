using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface ISortOptionService
    {
        /// <summary>
        /// Retrieves details of all SortOptions.
        /// </summary>
        /// <returns>Returns details of all SortOptions.</returns>
        Task<FhrResponse<SortOptions>> GetAsync();
    }
}
