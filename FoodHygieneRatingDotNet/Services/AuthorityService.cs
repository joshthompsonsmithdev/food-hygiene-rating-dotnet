using System.Threading.Tasks;
using FoodHygieneRatingDotNet.Entities;
using FoodHygieneRatingDotNet.Http;
using FoodHygieneRatingDotNet.Services.Interfaces;

namespace FoodHygieneRatingDotNet.Services
{
    /// <summary>
    /// Retrieves various data that's specific to local authorities.
    /// </summary>
    public class AuthorityService : IAuthorityService
    {
        private readonly IHttpService _httpService;

        public AuthorityService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <summary>
        /// Retrieves all authorities.
        /// </summary>
        /// <returns>Returns details of all authorities.</returns>
        public async Task<FhrResponse<Authorities>> GetAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.Authorities);

            var response = await _httpService.GetAsync<Authorities>(url);

            return response;
        }

        /// <summary>
        /// Retrieves details of a single authority, selected by Id.
        /// </summary>
        /// <param name="id">The id of the authority.</param>
        /// <returns>Returns details of a single authority, selected by Id.</returns>
        public async Task<FhrResponse<Authority>> GetAsync(int id)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.Authority, id);

            var response = await _httpService.GetAsync<Authority>(url);

            return response;
        }

        /// <summary>
        /// Retrieves a basic list of authorities (id/name), details can be retrieved by calling authorities/{id}.
        /// </summary>
        /// <returns>Returns a basic list of authorities (id/name), details can be retrieved by calling authorities/{id}.</returns>
        public async Task<FhrResponse<Authorities>> GetBasicAsync()
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.AuthoritiesBasic);

            var response = await _httpService.GetAsync<Authorities>(url);

            return response;
        }

        /// <summary>
        /// Retrieves details of all authorities, page parameters allow for page number and size specification.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>Returns details of all authorities, page parameters allow for page number and size specification.</returns>
        public async Task<FhrResponse<Authorities>> GetPagedAsync(int page, int size)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.AuthoritiesPaged, page, size);

            var response = await _httpService.GetAsync<Authorities>(url);

            return response;
        }

        /// <summary>
        /// Retrieves a basic list of authorities(id/name), details can be retrieved by calling authorities/{id}, 
        /// page parameters allow for page number and size specification.
        /// </summary>
        /// <param name="page">The page number to get.</param>
        /// <param name="size">The size of the page to be returned.</param>
        /// <returns>
        /// Returns a basic list of authorities(id/name), details can be retrieved by calling authorities/{id}, 
        /// page parameters allow for page number and size specification.
        /// </returns>
        public async Task<FhrResponse<Authorities>> GetPagedBasicAsync(int page, int size)
        {
            var url = _httpService.BuildApiUrl(HttpConstants.Endpoints.AuthoritiesPagedBasic, page, size);

            var response = await _httpService.GetAsync<Authorities>(url);

            return response;
        }
    }
}