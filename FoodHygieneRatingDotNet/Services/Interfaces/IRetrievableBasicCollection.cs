using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface IRetrievableBasicCollection<T> where T : EntityBase
    {
        /// <summary>
        /// Retrieves a basic (id/name), paged data set.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>Returns a basic (id/name), paged data set.</returns>
        Task<FhrResponse<T>> GetPagedBasicAsync(int page, int size);

        /// <summary>
        /// Retrieves a basic (id/name), paged data set.
        /// </summary>
        /// <returns>Returns a basic (id/name), paged data set.</returns>
        Task<FhrResponse<T>> GetBasicAsync();
    }
}
