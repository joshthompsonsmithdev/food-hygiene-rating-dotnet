using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services.Interfaces;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services
{
    public class SortOptionService : ISortOptionService
    {
        private readonly IHttpService _httpService;

        public SortOptionService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<FhrResponse<SortOptions>> GetAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.SortOptions);

            var response = await _httpService.GetAsync<SortOptions>(url);

            return response;
        }
    }
}
