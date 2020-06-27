using FoodHygieneRatingDotNet.Entities;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Http
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        Task<FhrResponse<T>> GetAsync<T>(string requestUri) where T : EntityBase;

        /// <summary>
        /// Builds a valid API URL.
        /// </summary>
        /// <param name="endpoint">The endpoint to use</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        string BuildApiUrl(string endpoint, params object[] parameters);
    }
}