using System.Threading.Tasks;
using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services.Interfaces;

namespace FoodHygieneRatingDotNet.Services
{
    /// <summary>
    /// Retrieves various data that's specific to countries.
    /// </summary>
    public class CountryService : ICountryService
    {
        private readonly IHttpService _httpService;

        public CountryService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <summary>
        /// Retrieves all countries.
        /// </summary>
        /// <returns>Returns details of all countries.</returns>
        public async Task<FhrResponse<Countries>> GetAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.Countries);

            var response = await _httpService.GetAsync<Countries>(url);

            return response;
        }

        /// <summary>
        /// Retrieves details of a single country, selected by Id.
        /// </summary>
        /// <param name="id">The id of the country.</param>
        /// <returns>Returns details of a single country, selected by Id.</returns>
        public async Task<FhrResponse<Country>> GetAsync(int id)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.Country, id);

            var response = await _httpService.GetAsync<Country>(url);

            return response;
        }

        /// <summary>
        /// Retrieves a basic list of countries (id/name), details can be retrieved by calling countries/{id}.
        /// </summary>
        /// <returns>Returns a basic list of countries (id/name), details can be retrieved by calling countries/{id}.</returns>
        public async Task<FhrResponse<Countries>> GetBasicAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.CountriesBasic);

            var response = await _httpService.GetAsync<Countries>(url);

            return response;
        }

        /// <summary>
        /// Retrieves details of all countries, page parameters allow for page number and size specification.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>Returns details of all countries, page parameters allow for page number and size specification.</returns>
        public async Task<FhrResponse<Countries>> GetPagedAsync(int page, int size)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.CountriesPaged, page, size);

            var response = await _httpService.GetAsync<Countries>(url);

            return response;
        }

        /// <summary>
        /// Retrieves a basic list of countries(id/name), details can be retrieved by calling countries/{id}, 
        /// page parameters allow for page number and size specification.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>
        /// Returns a basic list of countries(id/name), details can be retrieved by calling countries/{id}, 
        /// page parameters allow for page number and size specification.
        /// </returns>
        public async Task<FhrResponse<Countries>> GetPagedBasicAsync(int page, int size)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.CountriesPagedBasic, page, size);

            var response = await _httpService.GetAsync<Countries>(url);

            return response;
        }
    }
}