using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services.Interfaces
{ 
    public interface IRetrievableIndividual<T> where T : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<FhrResponse<T>> GetAsync(int id);
    }
}
