using System.Threading.Tasks;
using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services.Interfaces;

namespace FoodHygieneRatingDotNet.Services
{
    /// <summary>
    /// Retrieves various data that's specific to regions.
    /// </summary>
    public class RegionService : IRegionService
    {
        private readonly IHttpService _httpService;

        public RegionService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <summary>
        /// Retrieves all regions.
        /// </summary>
        /// <returns>Returns details of all regions.</returns>
        public async Task<FhrResponse<Regions>> GetAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.Regions);

            var response = await _httpService.GetAsync<Regions>(url);

            return response;
        }

        /// <summary>
        /// Retrieves details of a single region, selected by Id.
        /// </summary>
        /// <param name="id">The id of the region.</param>
        /// <returns>Returns details of a single region, selected by Id.</returns>
        public async Task<FhrResponse<Region>> GetAsync(int id)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.Region, id);

            var response = await _httpService.GetAsync<Region>(url);

            return response;
        }
        
        /// <summary>
        /// Retrieves a basic list of regions (id/name), details can be retrieved by calling regions/{id}.
        /// </summary>
        /// <returns>Returns a basic list of regions (id/name), details can be retrieved by calling regions/{id}.</returns>
        public async Task<FhrResponse<Regions>> GetBasicAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.RegionsBasic);

            var response = await _httpService.GetAsync<Regions>(url);

            return response;
        }

        /// <summary>
        /// Retrieves details of all regions, page parameters allow for page number and size specification.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>Returns details of all regions, page parameters allow for page number and size specification.</returns>
        public async Task<FhrResponse<Regions>> GetPagedAsync(int page, int size)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.RegionsPaged, page, size);

            var response = await _httpService.GetAsync<Regions>(url);

            return response;
        }

        /// <summary>
        /// Retrieves a basic list of regions(id/name), details can be retrieved by calling regions/{id}, 
        /// page parameters allow for page number and size specification.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>
        /// Returns a basic list of regions(id/name), details can be retrieved by calling regions/{id}, 
        /// page parameters allow for page number and size specification.
        /// </returns>
        public async Task<FhrResponse<Regions>> GetPagedBasicAsync(int page, int size)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.RegionsPagedBasic, page, size);

            var response = await _httpService.GetAsync<Regions>(url);

            return response;
        }
    }
}