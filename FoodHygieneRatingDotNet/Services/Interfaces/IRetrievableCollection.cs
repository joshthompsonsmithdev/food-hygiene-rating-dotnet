using System.Threading.Tasks;
using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface IRetrievableCollection<T> where T : EntityBase
    {
        /// <summary>
        /// Retrieves a detailed, paged data set.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>Returns a detailed, paged data set.</returns>
        Task<FhrResponse<T>> GetPagedAsync(int page, int size);

        /// <summary>
        /// Retrieves a detailed, paged data set.
        /// </summary>
        /// <returns>Returns a detailed, paged data set.</returns>
        Task<FhrResponse<T>> GetAsync();
    }
}