using System.Threading.Tasks;
using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services.Interfaces;

namespace FoodHygieneRatingDotNet.Services
{
    /// <summary>
    /// Retrieves various data that's specific to business types.
    /// </summary>
    public class BusinessTypeService : IBusinessTypeService
    {
        private readonly IHttpService _httpService;

        public BusinessTypeService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <summary>
        /// Retrieves all business types.
        /// </summary>
        /// <returns>Returns details of all business types.</returns>
        public async Task<FhrResponse<BusinessTypes>> GetAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.BusinessTypes);

            var response = await _httpService.GetAsync<BusinessTypes>(url);

            return response;
        }

        /// <summary>
        /// Retrieves details of a single business type, selected by Id.
        /// </summary>
        /// <param name="id">The id of the business type.</param>
        /// <returns>Returns details of a single business type, selected by Id.</returns>
        public async Task<FhrResponse<BusinessType>> GetAsync(int id)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.BusinessType, id);

            var response = await _httpService.GetAsync<BusinessType>(url);

            return response;
        }

        /// <summary>
        /// Retrieves a basic list of business types (id/name), details can be retrieved by calling business types/{id}.
        /// </summary>
        /// <returns>Returns a basic list of business types (id/name), details can be retrieved by calling business types/{id}.</returns>
        public async Task<FhrResponse<BusinessTypes>> GetBasicAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.BusinessTypesBasic);

            var response = await _httpService.GetAsync<BusinessTypes>(url);

            return response;
        }

        /// <summary>
        /// Retrieves details of all business types, page parameters allow for page number and size specification.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>Returns details of all business types, page parameters allow for page number and size specification.</returns>
        public async Task<FhrResponse<BusinessTypes>> GetPagedAsync(int page, int size)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.BusinessTypesPaged, page, size);

            var response = await _httpService.GetAsync<BusinessTypes>(url);

            return response;
        }

        /// <summary>
        /// Retrieves a basic list of business types(id/name), details can be retrieved by calling business types/{id}, 
        /// page parameters allow for page number and size specification.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>
        /// Returns a basic list of business types(id/name), details can be retrieved by calling business types/{id}, 
        /// page parameters allow for page number and size specification.
        /// </returns>
        public async Task<FhrResponse<BusinessTypes>> GetPagedBasicAsync(int page, int size)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.BusinessTypesPagedBasic, page, size);

            var response = await _httpService.GetAsync<BusinessTypes>(url);

            return response;
        }
    }
}