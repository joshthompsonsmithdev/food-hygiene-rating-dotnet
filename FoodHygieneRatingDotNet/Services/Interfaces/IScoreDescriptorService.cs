using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface IScoreDescriptorService
    {
        /// <summary>
        /// Retrieves details of all StoreDescriptors.
        /// </summary>
        /// <param name="establishmentId">The id of an <see cref="Establishment"/>.</param>
        /// <returns>Returns details of all StoreDescriptors.</returns>
        Task<FhrResponse<ScoreDescriptors>> GetAsync(int establishmentId);
    }
}
