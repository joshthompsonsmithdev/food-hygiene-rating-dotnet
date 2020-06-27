using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services.Interfaces;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services
{
    public class RatingOperatorService : IRatingOperatorService
    {
        private readonly IHttpService _httpService;

        public RatingOperatorService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<FhrResponse<RatingOperators>> GetAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.RatingOperators);

            var response = await _httpService.GetAsync<RatingOperators>(url);

            return response;
        }
    }
}
