using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services.Interfaces;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services
{
    public class RatingService : IRatingService
    {
        private readonly IHttpService _httpService;

        public RatingService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<FhrResponse<Ratings>> GetAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.Ratings);

            var response = await _httpService.GetAsync<Ratings>(url);

            return response;
        }
    }
}
