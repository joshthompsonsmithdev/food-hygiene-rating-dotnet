using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services.Interfaces;
using System.Threading.Tasks;

namespace FoodHygieneRatingDotNet.Services
{
    public class ScoreDescriptorService : IScoreDescriptorService
    {
        private readonly IHttpService _httpService;

        public ScoreDescriptorService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<FhrResponse<ScoreDescriptors>> GetAsync(int establishmentId)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.ScoreDescriptors, establishmentId);

            var response = await _httpService.GetAsync<ScoreDescriptors>(url);

            return response;
        }
    }
}
