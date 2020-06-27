using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{
    public interface ISchemeTypeService
    {
        /// <summary>
        /// Retrieves details of all SchemeTypes.
        /// </summary>
        /// <returns>Returns details of all SchemeTypes.</returns>
        Task<FhrResponse<SchemeTypes>> GetAsync();
    }
}
