using System.Threading.Tasks;
using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services.Interfaces;

namespace FoodHygieneRatingDotNet.Services
{
    /// <summary>
    /// Retrieves various data that's specific to scheme types.
    /// </summary>
    public class SchemeTypeService : ISchemeTypeService
    {
        private readonly IHttpService _httpService;

        public SchemeTypeService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<FhrResponse<SchemeTypes>> GetAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.SchemeTypes);

            var response = await _httpService.GetAsync<SchemeTypes>(url);

            return response;
        }
    }
}